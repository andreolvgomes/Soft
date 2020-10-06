using Soft.Application.ViewModels;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces.Services
{
    public interface IServiceAppBase<TViewModel> where TViewModel : ViewModelBase
    {
        /// <summary>
        /// Insert object into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Insert(TViewModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Update object in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(TViewModel model, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Delete object from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Delete(TViewModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Find object from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TViewModel Find(object param = null, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Get all objetct from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<TViewModel> All(object param = null, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);
    }
}