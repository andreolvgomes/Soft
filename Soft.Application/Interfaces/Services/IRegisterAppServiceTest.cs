//using Soft.Application.ViewModels;
//using Soft.Domain.Models;
//using Soft.Entities.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Soft.Application.Interfaces.Services
//{
//    public interface IRegisterAppServiceTest<TViewModel, TModel>
//        where TViewModel : ViewModelBase
//        where TModel : ModelBase
//    {
//        void Insert(TViewModel viewModel, IDbTransaction transaction = null);

//        void Update(TViewModel viewModel, IDbTransaction transaction = null);

//        void Delete(TViewModel viewModel, IDbTransaction transaction = null);

//        TViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null);

//        int Count(object param = null, IDbTransaction transaction = null);
//    }
//}