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
using System;

namespace Soft.Infra.IoC
{
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

        public Container Container()
        {
            return _container;
        }

        public void Init()
        {
            Application();
            Validations();
            Repositories();

            //container.RegisterCollection(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            _container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });
            _container.Register<ICommandDispatcher, CommandDispatcher>();

            //container.Register<IDatabase, InMemoryDatabase>(Lifestyle.Singleton);
            //_container.Verify();
        }

        private void Repositories()
        {
            _container.Register<IClientesRepository, ClientesRepository>();
            _container.Register<IPedidosRepository, PedidosRepository>();
            _container.Register<IPeitensRepository, PeitensRepository>();
            _container.Register<IProdutosRepository, ProdutosRepository>();
        }

        private void Validations()
        {
            _container.Register<IProdutosValidation, ProdutosValidation>();
        }

        private void Application()
        {
            _container.Register<IProdutosAppService, ProdutosAppService>();
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}