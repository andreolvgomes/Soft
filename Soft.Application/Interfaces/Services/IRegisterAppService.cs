using Soft.Application.ViewModels;
using Soft.Domain.Models;
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
    /// <summary>
    /// Interface Service default
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public interface IRegisterAppService<TViewModel> where TViewModel : ViewModelBase
    {
        /// <summary>
        /// Insert new record into database
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        long Insert(TViewModel viewModel, IDbTransaction transaction = null);

        /// <summary>
        /// Update data in the database
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Update(TViewModel viewModel, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Delete(TViewModel viewModel, IDbTransaction transaction = null);

        /// <summary>
        /// Find record
        /// </summary>
        /// <param name="param"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        TViewModel Find(object param = null, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        /// <summary>
        /// Find record one by one by offset
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        TViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null);

        /// <summary>
        /// Get all recoreds from database
        /// </summary>
        /// <param name="param"></param>
        /// <param name="selector"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<TViewModel> All(object param = null, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);
        
        /// <summary>
        /// Counter recored number from database
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Count(object param = null, IDbTransaction transaction = null);
    }
}