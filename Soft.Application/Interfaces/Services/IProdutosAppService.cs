﻿using Soft.Application.Interfaces;
using Soft.Application.ViewModels;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces.Services
{
    /// <summary>
    /// IProdutosAppService
    /// </summary>
    public interface IProdutosAppService //: IBaseAppService<Produtos>
    {
        /// <summary>
        /// Create new produto into database
        /// </summary>
        /// <param name="produtos"></param>
        void Create(ProdutosViewModel produtos);
        /// <summary>
        /// Update produto in the database
        /// </summary>
        /// <param name="produtos"></param>
        void Update(ProdutosViewModel produtos);
        /// <summary>
        /// Delete produto in the database
        /// </summary>
        /// <param name="pro_id"></param>
        void Remove(Int64 pro_id);
        /// <summary>
        /// Find produto by id
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        ProdutosViewModel FindById(Int64 pro_id);
    }
}
