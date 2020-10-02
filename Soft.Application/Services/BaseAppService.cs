using Soft.Application.Interfaces;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Services
{
    public class BaseAppService<TModel> : IBaseAppService<TModel> where TModel : BaseModel
    {
        public BaseAppService()
        {
        }

        public IEnumerable<TModel> All(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public long Create(TModel model, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(TModel model, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public TModel Find(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public int Update(TModel model, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }
    }
}
