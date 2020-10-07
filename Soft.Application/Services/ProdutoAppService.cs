using AutoMapper;
using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtosRepository = null;
        private readonly IMapper _mapper = null;

        public ProdutoAppService(IMapper mapper, IProdutoRepository produtosRepository)
        {
            _mapper = mapper;
            _produtosRepository = produtosRepository;
        }

        public long Insert(ProdutoViewModel viewModel, IDbTransaction transaction = null)
        {
            return _produtosRepository.Insert(_mapper.Map<Produto>(viewModel));
        }

        public int Update(ProdutoViewModel viewModel, Expression<Func<ProdutoViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _produtosRepository.Update(_mapper.Map<Produto>(viewModel), transaction: transaction);
        }

        public int Delete(ProdutoViewModel viewModel, IDbTransaction transaction = null)
        {
            return _produtosRepository.Delete(_mapper.Map<Produto>(viewModel), transaction: transaction);
        }

        public ProdutoViewModel Find(object param = null, Expression<Func<ProdutoViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<ProdutoViewModel>(_produtosRepository.Find(param: param, selector: 
                _mapper.Map<Expression<Func<Produto, object>>>(selector), transaction: transaction));
        }

        public ProdutoViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<ProdutoViewModel>(_produtosRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _produtosRepository.Count(param: param, transaction: transaction);
        }

        public IEnumerable<ProdutoViewModel> All(object param = null, Expression<Func<ProdutoViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtosRepository.All(param: param,
                selector: _mapper.Map<Expression<Func<Produto, object>>>(selector), transaction: transaction));
        }
    }
}