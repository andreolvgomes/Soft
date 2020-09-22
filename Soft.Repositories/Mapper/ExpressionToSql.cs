using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Data.Mapper
{
    public class ExpressionToSql
    {
        public static string Select<T>(Expression<Func<T, object>> selector)
        {
            StringBuilder sb = new StringBuilder();
            NewExpression body = (selector.Body as System.Linq.Expressions.NewExpression);
            if (body == null) return "";

            int i = 0;
            foreach (var x in body.Members)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append(string.Format("[{0}]", x.Name));
                i++;
            }
            return sb.ToString();
        }
    }
}
