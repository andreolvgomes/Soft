using Soft.Domain.Commands.Core;
using Soft.Domain.Commands.Pedidos.Command;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;

namespace Soft.Domain.Commands.Pedidos.Handler
{
    /// <summary>
    /// Command of the create Pedido
    /// </summary>
    public class CreatePedidoCommandHandler : ICommandHandler<CreatePedidoCommand>
    {
        /// <summary>
        /// Repository Pedido
        /// </summary>
        private readonly IPedidoRepository _pedidoRepository;

        /// <summary>
        /// CreatePedidoCommandHandler
        /// </summary>
        /// <param name="pedidosRepository"></param>
        public CreatePedidoCommandHandler(IPedidoRepository pedidosRepository)
        {
            _pedidoRepository = pedidosRepository;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="command"></param>
        public void Handle(CreatePedidoCommand command)
        {
            Pedido pedido = new Pedido();
            pedido.CreateAt = DateTime.Now;
            pedido.UpdateAt = DateTime.Now;
            
            _pedidoRepository.Insert(pedido);
        }
    }
}