//using Soft.Application.Interfaces.Services;
//using Soft.Domain.Interfaces.Repositories;
//using Soft.Entities.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Soft.Application.Services
//{
//    public class ServiceAppBase<TModel> : IServiceAppBase<TModel> where TModel : ModelBase
//    {
//        private readonly IRepository<TModel> _repository;

//        public ServiceAppBase(IRepository<TModel> repository)
//        {
//            _repository = repository;
//        }

//        public IEnumerable<TModel> All(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
//        {
//            return _repository.All(param: param, selector: selector, transaction: transaction);
//        }

//        public int Delete(TModel model, IDbTransaction transaction = null)
//        {
//            return _repository.Delete(model, transaction: transaction);
//        }

//        public TModel Find(object param = null, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
//        {
//            return _repository.Find(param: param, selector: selector, transaction: transaction);
//        }

//        public long Insert(TModel model, IDbTransaction transaction = null)
//        {
//            return _repository.Insert(model, transaction: transaction);
//        }

//        public int Update(TModel model, Expression<Func<TModel, object>> selector = null, IDbTransaction transaction = null)
//        {
//            return _repository.Update(model, selector: selector, transaction: transaction);
//        }
//    }
//}
