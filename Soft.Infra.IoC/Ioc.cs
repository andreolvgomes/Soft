using SimpleInjector;
using Soft.Application.Interfaces;
using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
using Soft.Domain.Boostrapper;
using Soft.Domain.Commands.Base;
using Soft.Domain.Interfaces.Repositories;
using Soft.Infra.Data.Repositories;

namespace Soft.Infra.IoC
{
    //public class Ioc
    //{
    //    public static void Register(Container container)
    //    {
    //        // Repositories
    //        container.Register<IClientesRepository, ClientesRepository>();
    //        container.Register<IPedidosRepository, PedidosRepository>();
    //        container.Register<IPeitensRepository, PeitensRepository>();
    //        container.Register<IProdutosRepository, ProdutosRepository>();

    //        //container.RegisterCollection(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
    //        container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });

    //        container.Register<ICommandDispatcher, CommandDispatcher>();
    //        //container.Register<IDatabase, InMemoryDatabase>(Lifestyle.Singleton);
    //    }
    //}

    public class Ioc
    {
        private static Ioc _instance = null;

        public static Ioc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Ioc();
                return _instance;
            }
        }

        private readonly Container _container;

        public Ioc()
        {
            _container = new Container();
        }

        public void Init()
        {
            // Application
            _container.Register<IProdutosAppService, ProdutosAppService>();

            // Validations
            _container.Register<IProdutosValidation, ProdutosValidation>();

            _container.Register<IClientesRepository, ClientesRepository>();
            _container.Register<IPedidosRepository, PedidosRepository>();
            _container.Register<IPeitensRepository, PeitensRepository>();
            _container.Register<IProdutosRepository, ProdutosRepository>();

            //_container.Register(typeof(IRepository<>), new[] { typeof(IRepository<>).Assembly });

            //container.RegisterCollection(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            _container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });

            _container.Register<ICommandDispatcher, CommandDispatcher>();
            //container.Register<IDatabase, InMemoryDatabase>(Lifestyle.Singleton);
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}