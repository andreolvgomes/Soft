﻿using Soft.Application.Interfaces;
using Soft.Application.ViewModels;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces.Services
{
    /// <summary>
    /// ISubcategoriaAppService
    /// </summary>
    public interface ISubcategoriaAppService : IRegisterAppService<SubcategoriaViewModel>
    {
        Int64 GetSub_idBySub_descricao(string sub_descricao);
    }
}