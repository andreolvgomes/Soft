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
    public class ViewModelToDomainModelMapping : Profile
    {
        public ViewModelToDomainModelMapping()
        {
            CreateMap<ProdutoViewModel, Produto>();
            //Expression < Func<TModel, object>>
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<SubcategoriaViewModel, Subcategoria>();
            CreateMap<FamiliasprodViewModel, Familiasprod>();
        }
    }
}