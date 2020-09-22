using Dapper;
using Soft.Domain.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Infra.Data.Mapper
{
    public static class DapperExtensions
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, string> TypeTableName
            = new ConcurrentDictionary<RuntimeTypeHandle, string>();

        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> KeyProperties
            = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> TypeProperties
            = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> IdentiyProperties
            = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

        public static TModel Get<TModel>(this IDbConnection cnn, dynamic param, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null) where TModel : BaseModel
        {
            QueryTest query = GetQuery(true, param, selector);
            return cnn.Query<TModel>(query.Query, query.Param, transaction: transaction).FirstOrDefault();
        }

        public static IEnumerable<TModel> All<TModel>(this IDbConnection cnn, object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null) where TModel : BaseModel
        {
            QueryTest query = GetQuery<TModel>(false, param as object, selector);
            return cnn.Query<TModel>(query.Query, query.Param, transaction: transaction);
        }

        public static IEnumerable<TModel> All<TModel>(this IDbConnection cnn, object param = null, IDbTransaction transaction = null) where TModel : BaseModel
        {
            QueryTest query = GetQuery<TModel>(false, param as object, null);
            return cnn.Query<TModel>(query.Query, query.Param, transaction: transaction);
        }

        private static QueryTest GetQuery<TModel>(bool is_topOne, dynamic param = null, Expression<Func<TModel, object>> selector = null) where TModel : BaseModel
        {
            QueryTest query = new QueryTest();
            string _selector = "*";
            if (selector != null)
                _selector = ExpressionToSql.Select<TModel>(selector);

            query.Query = string.Format("select {0} {1} from dbo.[{2}]", (is_topOne) ? "top 1" : "", _selector, GetTableName<TModel>());
            query.Param = null;

            if (param != null)
            {
                object parameters = param;
                IEnumerable<PropertyInfo> properties = parameters.GetType().GetProperties();

                query.Query += " where ";
                int j = 0;
                if (properties.Count() > 0 && !(parameters is string))
                {
                    foreach (PropertyInfo property in properties)
                    {
                        if (j > 0)
                            query.Query += " and ";
                        query.Query += string.Format("[{0}] = @{0}", property.Name);
                        j++;
                    }
                    query.Param = param;
                }
                else
                {
                    properties = KeyPropertiesCache(typeof(TModel));
                    if (properties.Count() > 1)
                    {
                        List<string> keys = (from x in properties select x.Name).ToList<string>();
                        throw new ArgumentException(string.Format("O modelo ({0}) tem mais de uma propriedade [Key] ('{1}'), não é possível localizar o registro com uma única informação [Key]", GetTableName<TModel>(), string.Join(",", keys.ToArray())));
                    }
                    PropertyInfo property = properties.FirstOrDefault();
                    query.Query += string.Format("[{0}] = @{0}", property.Name);

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add(string.Format("@{0}", property.Name), parameters);

                    query.Param = dynamicParameters;
                }
            }
            return query;
        }

        public static long Insert<TEntity>(this IDbConnection cnn, TEntity model, IDbTransaction transaction = null) where TEntity : BaseModel
        {
            Type type = typeof(TEntity);

            StringBuilder sbColumnList = new StringBuilder(null);

            IEnumerable<PropertyInfo> allProperties = TypePropertiesCache(type);
            IEnumerable<PropertyInfo> keyProperties = KeyPropertiesCache(type);

            if (keyProperties.Count() == 0)
                throw new ArgumentException("O modelo deve ter pelo menos uma propriedade [Key]");

            IEnumerable<PropertyInfo> field_identity = IdentyPropertiesCache(type);
            IEnumerable<PropertyInfo> fields = allProperties.Except(field_identity);

            for (var i = 0; i < fields.Count(); i++)
            {
                PropertyInfo property = fields.ElementAt(i);
                sbColumnList.AppendFormat("[{0}]", Name(property));
                if (i < fields.Count() - 1)
                    sbColumnList.Append(", ");
            }

            StringBuilder sbParameterList = new StringBuilder(null);
            for (var i = 0; i < fields.Count(); i++)
            {
                PropertyInfo property = fields.ElementAt(i);
                sbParameterList.AppendFormat("@{0}", Name(property).Replace(" ", "_"));
                if (i < fields.Count() - 1)
                    sbParameterList.Append(", ");
            }

            return Insert<TEntity>(cnn, model, transaction, GetTableName<TEntity>(), sbColumnList.ToString(), sbParameterList.ToString(), fields, field_identity);
        }

        private static long Insert<TEntity>(IDbConnection cnn, TEntity model, IDbTransaction transaction, String tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> fields, IEnumerable<PropertyInfo> field_identity) where TEntity : BaseModel
        {
            string cmd = String.Format("insert into dbo.[{0}] ({1}) values ({2})", tableName, columnList, parameterList);
            cnn.Execute(cmd, model, transaction: transaction);

            if (field_identity != null && field_identity.Count() > 0)
            {
                var ident_current = cnn.Query<long>(string.Format("select IDENT_CURRENT ('{0}')", tableName), transaction: transaction).FirstOrDefault();
                //var ident_current = connection.Query<long>("select scope_identity()", transaction: transaction).FirstOrDefault();
                PropertyInfo identity = field_identity.FirstOrDefault();
                identity.SetValue(model, CastValue(identity, ident_current), null);
                return ident_current;
            }
            return 0;
        }

        public static int Update<TEntity>(this IDbConnection cnn, TEntity model, IDbTransaction transaction = null) where TEntity : BaseModel
        {
            Type type = typeof(TEntity);

            IEnumerable<PropertyInfo> keyProperties = KeyPropertiesCache(type);
            if (keyProperties.Count() == 0)
                throw new ArgumentException("O modelo deve ter pelo menos uma propriedade [Key]");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update dbo.[{0}] set ", GetTableName<TEntity>());

            IEnumerable<PropertyInfo> allProperties = TypePropertiesCache(type);
            IEnumerable<PropertyInfo> identyProperties = IdentyPropertiesCache(type);
            IEnumerable<PropertyInfo> fields = allProperties.Except(identyProperties);

            int j = 0;
            foreach (PropertyInfo property in fields)
            {
                string property_name = Name(property);

                if (j > 0)
                    sb.AppendFormat(", ");
                sb.AppendFormat("[{0}] = @{1}", property_name, property_name.Replace(" ", "_"));
                j++;
            }
            sb.Append(" where ");
            for (var i = 0; i < keyProperties.Count(); i++)
            {
                PropertyInfo property = keyProperties.ElementAt(i);

                object value = property.GetValue(model, null);
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                    throw new Exception(string.Format("Uma das propriedades definida como [Key] está no formato incorreto. Value = Null ou Empty: \"{0}\"", property.Name));

                sb.AppendFormat("[{0}] = @{0}", Name(property));
                if (i < keyProperties.Count() - 1)
                    sb.AppendFormat(" and ");
            }
            return cnn.Execute(sb.ToString(), model, transaction: transaction);
        }

        public static int Delete<TEntity>(this IDbConnection cnn, TEntity model, IDbTransaction transaction = null) where TEntity : BaseModel
        {
            if (model == null)
                throw new ArgumentException("Cannot Delete null Object", "model");

            IEnumerable<PropertyInfo> keyProperties = KeyPropertiesCache(typeof(TEntity));
            if (keyProperties.Count() == 0)
                throw new ArgumentException("O modelo deve ter pelo menos uma propriedade [Key]");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from dbo.[{0}] where ", GetTableName<TEntity>());

            for (var i = 0; i < keyProperties.Count(); i++)
            {
                PropertyInfo property = keyProperties.ElementAt(i);
                sb.AppendFormat("[{0}] = @{0}", Name(property));
                if (i < keyProperties.Count() - 1)
                    sb.AppendFormat(" and ");
            }
            return cnn.Execute(sb.ToString(), model, transaction: transaction);
        }

        private static object CastValue(PropertyInfo identity, long ident_current)
        {
            if (identity.PropertyType == typeof(int))
                return (int)ident_current;
            if (identity.PropertyType == typeof(Int16))
                return (Int16)ident_current;
            if (identity.PropertyType == typeof(Int32))
                return (Int32)ident_current;
            if (identity.PropertyType == typeof(Int64))
                return ident_current;
            return ident_current;
        }

        private static IEnumerable<PropertyInfo> KeyPropertiesCache(Type type)
        {
            IEnumerable<PropertyInfo> pi;
            if (KeyProperties.TryGetValue(type.TypeHandle, out pi))
                return pi;

            IEnumerable<PropertyInfo> allProperties = TypePropertiesCache(type);
            IEnumerable<PropertyInfo> keyProperties = allProperties.Where(p => p.GetCustomAttributes(true).Any(a => (a as ColumnModelAttribute).IsPrimaryKey)).ToList();

            KeyProperties[type.TypeHandle] = keyProperties;
            return keyProperties;
        }

        private static string Name(PropertyInfo property)
        {
            object[] attrs = property.GetCustomAttributes(typeof(ColumnModelAttribute), true);
            if (attrs.Length > 0)
            {
                ColumnModelAttribute att = attrs[0] as ColumnModelAttribute;
                if (att != null)
                    return att.ColumName;
            }
            return "";
        }

        private static string GetTableName<TEntity>() where TEntity : BaseModel
        {
            Type type = typeof(TEntity);

            string name = "";
            if (!TypeTableName.TryGetValue(type.TypeHandle, out name))
            {
                name = ((TEntity)Activator.CreateInstance(typeof(TEntity)) as BaseModel).TableName;
                TypeTableName[type.TypeHandle] = name;
            }
            return name;
        }

        private static IEnumerable<PropertyInfo> TypePropertiesCache(Type type)
        {
            IEnumerable<PropertyInfo> pis;
            if (TypeProperties.TryGetValue(type.TypeHandle, out pis))
                return pis;

            IEnumerable<PropertyInfo> properties = type.GetProperties().Where(IsWriteable).ToArray() as PropertyInfo[];
            TypeProperties[type.TypeHandle] = properties;
            return properties;
        }

        private static bool IsWriteable(PropertyInfo property)
        {
            object[] attributes = property.GetCustomAttributes(typeof(ColumnModelAttribute), false);
            if (attributes.Length == 1)
            {
                ColumnModelAttribute write = (ColumnModelAttribute)attributes[0];
                if (write != null)
                    return true;
            }
            return false;
        }

        private static IEnumerable<PropertyInfo> IdentyPropertiesCache(Type type)
        {
            IEnumerable<PropertyInfo> pi;
            if (IdentiyProperties.TryGetValue(type.TypeHandle, out pi))
                return pi;

            IEnumerable<PropertyInfo> allProperties = TypePropertiesCache(type);
            IEnumerable<PropertyInfo> identyProperties = allProperties.Where(p => p.GetCustomAttributes(true).Any(a => (a as ColumnModelAttribute).IsIdentity)).ToList();

            IdentiyProperties[type.TypeHandle] = identyProperties;
            return identyProperties;
        }
    }
}
