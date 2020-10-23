using AutoMapper;
using Soft.Application.Interfaces.Services;
using Soft.Domain.Commands.Core.Dispatcher;
using Soft.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Services
{
    public class PedidoAppService: IPedidoAppService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDispatcher _commandDispatcher;

        public PedidoAppService(IMapper mapper, IPedidoRepository pedidoRepository, ICommandDispatcher commandDispatcher)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
            _commandDispatcher = commandDispatcher;
        }
    }
}