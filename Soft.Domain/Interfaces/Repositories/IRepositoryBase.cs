using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Respository base
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IRespositoryBase<TModel> where TModel : BaseModel
    {
        /// <summary>
        /// Insert model into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Insert(TModel model, IDbTransaction transaction = null);
        /// <summary>
        /// Update model to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(TModel model, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);
        /// <summary>
        /// Delete model from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Delete(TModel model, IDbTransaction transaction = null);
        /// <summary>
        /// Find model from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel Find(object param = null, IDbTransaction transaction = null);
        /// <summary>
        /// Find all model's from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> All(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);
    }
}