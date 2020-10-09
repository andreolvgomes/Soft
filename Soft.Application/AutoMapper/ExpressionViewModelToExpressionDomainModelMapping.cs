using AutoMapper;
using Soft.Application.ViewModels;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.AutoMapper
{
    public class ExpressionViewModelToExpressionDomainModelMapping : Profile
    {
        public ExpressionViewModelToExpressionDomainModelMapping()
        {
            CreateMap<Expression<Func<ProdutoViewModel, object>>, Expression<Func<Produto, object>>>();
            CreateMap<Expression<Func<CategoriaViewModel, object>>, Expression<Func<Categoria, object>>>();
            CreateMap<Expression<Func<SubcategoriaViewModel, object>>, Expression<Func<Subcategoria, object>>>();
            CreateMap<Expression<Func<FamiliasprodViewModel, object>>, Expression<Func<Familiasprod, object>>>();
            CreateMap<Expression<Func<PedidoViewModel, object>>, Expression<Func<Pedido, object>>>();
        }
    }
}