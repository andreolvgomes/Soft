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
    public interface IRegisterAppService<TViewModel> where TViewModel : ViewModelBase
    {
        long Insert(TViewModel viewModel, IDbTransaction transaction = null);

        int Update(TViewModel viewModel, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        int Delete(TViewModel viewModel, IDbTransaction transaction = null);

        TViewModel Find(object param = null, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        TViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null);

        IEnumerable<TViewModel> All(object param = null, Expression<Func<TViewModel, object>> selector = null, IDbTransaction transaction = null);

        int Count(object param = null, IDbTransaction transaction = null);
    }
}