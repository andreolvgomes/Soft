using Soft.Domain.Commands.Base;
using Soft.Domain.Commands.Pedidos.Command;
using Soft.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Pedidos.Handler
{
    public class CancelPedidoCommandHandler : ICommandHandler<CancelPedidoCommand>
    {
        private readonly IPedidosRepository _pedidosRepository;

        public CancelPedidoCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public void Handle(CancelPedidoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}