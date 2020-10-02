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
    public class CreatePedidosCommandHandler : ICommandHandler<CreatePedidosCommand>
    {
        private readonly IPedidosRepository _pedidosRepository;

        public CreatePedidosCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public void Handle(CreatePedidosCommand command)
        {
            //Pedidos pedidos = command.Pedidos;
            //_pedidosRepository.Insert(pedidos);
        }
    }
}