using SimpleInjector;
using Soft.Application.Interfaces;
using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
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
            _container.RegisterAppServices();
            _container.RegisterAppValidations();
            _container.RegisterRepositories();
            _container.RegisterCommands();
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}