using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces
{
    public interface IBaseAppService<TModel> where TModel : BaseModel
    {
        long Create(TModel model, IDbTransaction transaction = null);

        int Update(TModel model, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);

        int Delete(TModel model, IDbTransaction transaction = null);

        TModel Find(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);

        IEnumerable<TModel> All(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null);
    }
}