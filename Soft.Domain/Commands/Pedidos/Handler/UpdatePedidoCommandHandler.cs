using Soft.Domain.Commands.Base;
using Soft.Domain.Commands.Pedidos.Command;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Pedidos.Handler
{
    /// <summary>
    /// Command of the update Pedido
    /// </summary>
    public class UpdatePedidoCommandHandler : ICommandHandler<UpdatePedidoCommand>
    {
        /// <summary>
        /// Repository of Pedido
        /// </summary>
        private readonly IPedidoRepository _pedidoRepository;

        /// <summary>
        /// UpdatePedidoCommandHandler
        /// </summary>
        /// <param name="pedidosRepository"></param>
        public UpdatePedidoCommandHandler(IPedidoRepository pedidosRepository)
        {
            _pedidoRepository = pedidosRepository;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="command"></param>
        public void Handle(UpdatePedidoCommand command)
        {
            Pedido pedido = new Pedido();
            pedido.UpdateAt = DateTime.Now;

            _pedidoRepository.Update(pedido);
        }
    }
}