using Dapper;
using Soft.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Soft.Entities.Models;

namespace Soft.Infra.Data.Repositories
{
    /// <summary>
    /// Repository base
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class Repository<TModel> : IRepository<TModel> where TModel : ModelBase
    {

        /// <summary>
        /// Get all objetct from database
        /// </summary>
        /// <param name="param"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<TModel> All(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.All<TModel>(param as object, transaction: transaction);
        }

        /// <summary>
        /// Delete object from database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Delete(TModel model, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Delete<TModel>(model, transaction: transaction);
        }

        /// <summary>
        /// Find object from database
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TModel Find(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Find<TModel>(param, selector, transaction);
        }

        /// <summary>
        /// Insert object into database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public long Insert(TModel model, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Insert<TModel>(model, transaction: transaction);
        }

        /// <summary>
        /// Update object in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Update(TModel model, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Update<TModel>(model, transaction: transaction);
        }

        /// <summary>
        /// Check if there is a record in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        //public bool Exists(TModel model, IDbTransaction transaction = null)
        //{
        //    using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
        //        return cnn.Exists<TModel>(model, transaction: transaction);
        //}

        /// <summary>
        /// Returns the number of records
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Count(object param = null, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Count<TModel>(param, transaction: transaction);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Find record by offset
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="param"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TModel FindOffset(int offset, object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.FindOffset<TModel>(offset, param: param, transaction: transaction);
        }

        /// <summary>
        /// Check if there is a recored in the database
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Exists(object param = null, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Exists<TModel>(param: param, transaction: transaction);
        }

        /// <summary>
        /// Return value from database
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="param"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TResult Value<TResult>(object param, Expression<Func<TModel, object>> selector, IDbTransaction transaction = null)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
                return cnn.Value<TModel, TResult>(param: param, selector: selector, transaction: transaction);
        }
    }
}