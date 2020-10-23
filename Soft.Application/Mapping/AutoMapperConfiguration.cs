using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Mapping
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainModelToViewModelMapping());
                cfg.AddProfile(new ViewModelToCommandMapping());
                cfg.AddProfile(new ViewModelToDomainModelMapping());
                cfg.AddProfile(new ExpressionViewModelToExpressionDomainModelMapping());
            });
        }
    }
}