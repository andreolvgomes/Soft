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
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteAppService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<ClienteViewModel> All(object param = null, Expression<Func<ClienteViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.All(param: param,
                selector: _mapper.Map<Expression<Func<Cliente, object>>>(selector), transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _clienteRepository.Count(param: param, transaction: transaction);
        }

        public int Delete(ClienteViewModel viewModel, IDbTransaction transaction = null)
        {
            return _clienteRepository.Delete(_mapper.Map<Cliente>(viewModel), transaction: transaction);
        }

        public ClienteViewModel Find(object param = null, Expression<Func<ClienteViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<ClienteViewModel>(_clienteRepository.Find(param: param, selector:
                _mapper.Map<Expression<Func<Cliente, object>>>(selector), transaction: transaction));
        }

        public ClienteViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<ClienteViewModel>(_clienteRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public long Insert(ClienteViewModel viewModel, IDbTransaction transaction = null)
        {
            return _clienteRepository.Insert(_mapper.Map<Cliente>(viewModel));
        }

        public int Update(ClienteViewModel viewModel, Expression<Func<ClienteViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _clienteRepository.Update(_mapper.Map<Cliente>(viewModel),
                selector: _mapper.Map<Expression<Func<Cliente, object>>>(selector), transaction: transaction);
        }
    }
}
