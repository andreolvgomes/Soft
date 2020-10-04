using Soft.Domain.Commands.Base;
using Soft.Domain.Commands.Pedidos.Command;
using Soft.Domain.Interfaces.Repositories;

namespace Soft.Domain.Commands.Pedidos.Handler
{
    public class CreatePedidoCommandHandler : ICommandHandler<CreatePedidoCommand>
    {
        private readonly IPedidosRepository _pedidosRepository;

        public CreatePedidoCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public void Handle(CreatePedidoCommand command)
        {
            //Pedidos pedidos = command.Pedidos;
            //_pedidosRepository.Insert(pedidos);
        }
    }
}