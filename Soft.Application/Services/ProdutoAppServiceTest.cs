//using AutoMapper;
//using AutoMapper.QueryableExtensions.Impl;
//using Soft.Application.Interfaces.Services;
//using Soft.Application.ViewModels;
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
//    public class ProdutoAppServiceTest<TViewModel, TModel> : IRegisterAppServiceTest<TViewModel, TModel>
//        where TViewModel : ViewModelBase 
//        where TModel : ModelBase
//    {
//        private readonly IProdutosRepository _produtosRepository = null;
//        private readonly IMapper _mapper = null;

//        public ProdutoAppServiceTest(IMapper mapper, IProdutosRepository produtosRepository)
//        {
//            _mapper = mapper;
//            _produtosRepository = produtosRepository;
//        }

//        public int Count(object param = null, IDbTransaction transaction = null)
//        {
//            return 0;
//        }

//        public void Delete(TViewModel viewModel, IDbTransaction transaction = null)
//        {
            
//        }

//        public TViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(TViewModel viewModel, IDbTransaction transaction = null)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(TViewModel viewModel, IDbTransaction transaction = null)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}