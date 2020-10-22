using Soft.Domain.Commands.Core;
using Soft.Domain.Commands.Pedidos.Command;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Pedidos.Handler
{
    /// <summary>
    /// CancelPedidoCommandHandler
    /// </summary>
    public class CancelPedidoCommandHandler : ICommandHandler<CancelPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        /// <summary>
        /// CancelPedidoCommandHandler
        /// </summary>
        /// <param name="pedidosRepository"></param>
        public CancelPedidoCommandHandler(IPedidoRepository pedidosRepository)
        {
            _pedidoRepository = pedidosRepository;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="command"></param>
        public void Handle(CancelPedidoCommand command)
        {
            Pedido pedido = new Pedido();
            pedido.UpdateAt = DateTime.Now;
            pedido.Ped_canc = true;

            _pedidoRepository.Update(pedido);
        }
    }
}