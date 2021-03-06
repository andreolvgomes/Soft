﻿using AutoMapper;
using Soft.Application.ViewModels;
using Soft.Domain.Commands.Pedidos.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Mapping
{
    public class ViewModelToCommandMapping : Profile
    {
        public ViewModelToCommandMapping()
        {
            CreateMap<PedidoViewModel, CreatePedidoCommand>();
            CreateMap<PedidoViewModel, UpdatePedidoCommand>();
            CreateMap<PedidoViewModel, CancelPedidoCommand>();
        }
    }
}