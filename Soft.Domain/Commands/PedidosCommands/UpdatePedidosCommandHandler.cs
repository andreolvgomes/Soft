using Soft.Domain.Commands.Base;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.PedidosCommands
{
    public class UpdatePedidosCommandHandler : ICommandHandler<PedidosCommand>
    {
        private readonly IPedidosRepository _pedidosRepository;

        public UpdatePedidosCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public override void Handler(PedidosCommand command)
        {
            Pedidos pedidos = command.Pedidos;
            base.SetChangesAt<Pedidos>(pedidos);
            _pedidosRepository.Update(pedidos);
        }
    }
}