using AutoMapper;
using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Domain.Interfaces.Repositories;
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
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutosRepository _produtosRepository = null;
        private readonly IMapper _mapper = null;

        public ProdutoAppService(IMapper mapper, IProdutosRepository produtosRepository)
        {
            _mapper = mapper;
            _produtosRepository = produtosRepository;
        }

        public ProdutoViewModel FindById(long pro_id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtosRepository.Find(new { Pro_id = pro_id }));
        }

        public void Insert(ProdutoViewModel viewModel, IDbTransaction transaction = null)
        {
            _produtosRepository.Insert(_mapper.Map<Produto>(viewModel));
        }

        public void Update(ProdutoViewModel viewModel, Expression<Func<ProdutoViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            _produtosRepository.Update(_mapper.Map<Produto>(viewModel), transaction: transaction);
        }

        public void Delete(ProdutoViewModel viewModel, IDbTransaction transaction = null)
        {
            _produtosRepository.Delete(_mapper.Map<Produto>(viewModel), transaction: transaction);
        }

        public ProdutoViewModel Find(object param = null, Expression<Func<ProdutoViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> All()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtosRepository.All());
        }

        public ProdutoViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<ProdutoViewModel>(_produtosRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _produtosRepository.Count(param: param, transaction: transaction);
        }
    }
}