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
    /// IFamiliasprodAppService
    /// </summary>
    public interface IFamiliasprodAppService : IRegisterAppService<FamiliasprodViewModel>
    {
        Int64 GetFam_idByFam_descricao(string fam_descricao);
    }
}