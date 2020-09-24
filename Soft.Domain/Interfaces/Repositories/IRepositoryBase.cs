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
    public interface IRepositoryBase<TModel> where TModel : BaseModel
    {
        /// <summary>
        /// Insert object into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Insert(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Update object in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(TModel model, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Delete object from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Delete(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Find object from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel Find(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Get all objetct from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> All(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Check if there is a record in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Exists(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Returns the number of records
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Count(object param = null, IDbTransaction transaction = null);
    }
}