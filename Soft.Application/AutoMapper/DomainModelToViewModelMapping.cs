using AutoMapper;
using Soft.Application.ViewModels;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.AutoMapper
{
    public class DomainModelToViewModelMapping : Profile
    {
        public DomainModelToViewModelMapping()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}