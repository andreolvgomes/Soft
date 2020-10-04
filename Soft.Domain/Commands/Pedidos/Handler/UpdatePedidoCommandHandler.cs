using Soft.Domain.Commands.Base;
using Soft.Domain.Commands.Pedidos.Command;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Pedidos.Handler
{
    public class UpdatePedidoCommandHandler : ICommandHandler<UpdatePedidoCommand>
    {
        private readonly IPedidosRepository _pedidosRepository;

        public UpdatePedidoCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public void Handle(UpdatePedidoCommand command)
        {
            //Pedidos pedidos = command.Pedidos;
            //_pedidosRepository.Update(pedidos);
        }
    }
}