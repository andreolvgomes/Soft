using AutoMapper;
using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Domain.Interfaces.Repositories;
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
    public class VendedorAppService : IVendedorAppService
    {
        private readonly IVendedorRepository _vendedorRepository = null;
        private readonly IMapper _mapper = null;

        public VendedorAppService(IMapper mapper, IVendedorRepository vendedorRepository)
        {
            _mapper = mapper;
            _vendedorRepository = vendedorRepository;
        }

        public IEnumerable<VendedorViewModel> All(object param = null, Expression<Func<VendedorViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<IEnumerable<VendedorViewModel>>(_vendedorRepository.All(param: param,
                selector: _mapper.Map<Expression<Func<Vendedor, object>>>(selector), transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _vendedorRepository.Count(param: param, transaction: transaction);
        }

        public int Delete(VendedorViewModel viewModel, IDbTransaction transaction = null)
        {
            return _vendedorRepository.Delete(_mapper.Map<Vendedor>(viewModel), transaction: transaction);
        }

        public VendedorViewModel Find(object param = null, Expression<Func<VendedorViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<VendedorViewModel>(_vendedorRepository.Find(param: param, selector:
                _mapper.Map<Expression<Func<Vendedor, object>>>(selector), transaction: transaction));
        }

        public VendedorViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<VendedorViewModel>(_vendedorRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public long Insert(VendedorViewModel viewModel, IDbTransaction transaction = null)
        {
            return _vendedorRepository.Insert(_mapper.Map<Vendedor>(viewModel), transaction: transaction);
        }

        public int Update(VendedorViewModel viewModel, Expression<Func<VendedorViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _vendedorRepository.Update(_mapper.Map<Vendedor>(viewModel),
                selector: _mapper.Map<Expression<Func<Vendedor, object>>>(selector), transaction: transaction);
        }
    }
}
