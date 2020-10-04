using SimpleInjector;
using Soft.Domain.Commands.Base;
using Soft.Domain.Interfaces.Repositories;
using Soft.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Boostrapper
{
    public class Registry
    {
        public static void Register(Container container)
        {
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IPedidosRepository, PedidoRepository>();
            container.Register<IPeitemRepository, PeitemRepository>();
            container.Register<IProdutosRepository, ProdutoRepository>();

            container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });
            container.Register<ICommandDispatcher, CommandDispatcher>();
        }
    }
}