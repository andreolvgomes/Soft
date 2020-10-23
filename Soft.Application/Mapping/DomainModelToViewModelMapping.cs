using AutoMapper;
using Soft.Application.ViewModels;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Mapping
{
    public class DomainModelToViewModelMapping : Profile
    {
        public DomainModelToViewModelMapping()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Subcategoria, SubcategoriaViewModel>();
            CreateMap<Familiasprod, FamiliasprodViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<Vendedor, VendedorViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}