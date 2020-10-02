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
    public class UpdatePedidosCommandHandler : ICommandHandler<UpdatePedidosCommand>
    {
        private readonly IPedidosRepository _pedidosRepository;

        public UpdatePedidosCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public void Handle(UpdatePedidosCommand command)
        {
            //Pedidos pedidos = command.Pedidos;
            //_pedidosRepository.Update(pedidos);
        }
    }
}