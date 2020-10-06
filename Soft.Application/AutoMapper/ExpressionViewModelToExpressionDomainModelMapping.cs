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
        }
    }
}