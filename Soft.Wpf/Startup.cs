﻿using AutoMapper;
using SimpleInjector;
using Soft.Application.AutoMapper;
using Soft.Infra.IoC;
using Soft.Wpf.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf
{
    public class Startup
    {
        public void Register()
        {
            Ioc.Instance.Init();

            Container container = Ioc.Instance.Container();
            container.Register<ProdutosController>();

            // register automapper
            MapperConfiguration config = AutoMapperConfiguration.RegisterMappings();
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
        }
    }
}