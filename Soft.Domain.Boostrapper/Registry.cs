//using SimpleInjector;
//using Soft.Domain.Commands.Base;
//using Soft.Domain.Interfaces.Repositories;
//using Soft.Infra.Data.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Soft.Domain.Boostrapper
//{
//    public class Registry
//    {
//        public void Register(Container container)
//        {
//            // Repositories
//            container.Register<IClientesRepository, ClientesRepository>();
//            container.Register<IPedidosRepository, PedidosRepository>();
//            container.Register<IPeitensRepository, PeitensRepository>();
//            container.Register<IProdutosRepository, ProdutosRepository>();

//            //container.RegisterCollection(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
//            container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });

//            container.Register<ICommandDispatcher, CommandDispatcher>();
//            //container.Register<IDatabase, InMemoryDatabase>(Lifestyle.Singleton);
//        }
//    }
//}
