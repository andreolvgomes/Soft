using AutoMapper;
using Soft.Application.ViewModels;
using Soft.Domain.Commands.Pedidos.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.AutoMapper
{
    public class ViewModelToCommandMapping : Profile
    {
        public ViewModelToCommandMapping()
        {
            CreateMap<ProdutoViewModel, CreatePedidoCommand>();
            CreateMap<ProdutoViewModel, UpdatePedidoCommand>();
        }
    }
}
