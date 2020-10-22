﻿using SimpleInjector;
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
            Registry.Register(_container);

            // Application
            _container.Register<IProdutoAppService, ProdutoAppService>();
            _container.Register<ICategoriaAppService, CategoriaAppService>();
            _container.Register<ISubcategoriaAppService, SubcategoriaAppService>();
            _container.Register<IFamiliasprodAppService, FamiliasprodAppService>();
            _container.Register<IVendedorAppService, VendedorAppService>();

            // Validations
            _container.Register<IVendedorValidation, VendedorValidation>();
            _container.Register<ICategoriaValidation, CategoriaValidation>();
            _container.Register<IFamiliasprodValidation, FamiliasprodValidation>();
            _container.Register<IProdutoValidation, ProdutoValidation>();
            _container.Register<ISubcategoriaValidation, SubcategoriaValidation>();
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}