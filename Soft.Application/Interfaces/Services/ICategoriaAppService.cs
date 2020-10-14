using Soft.Application.Interfaces;
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
    /// IProdutosAppService
    /// </summary>
    public interface ICategoriaAppService : IRegisterAppService<CategoriaViewModel>
    {
        /// <summary>
        /// Get id by description Cat_descricao
        /// </summary>
        /// <param name="cat_descricao"></param>
        /// <returns></returns>
        Int64 GetCat_idByCat_descricao(string cat_descricao);
    }
}