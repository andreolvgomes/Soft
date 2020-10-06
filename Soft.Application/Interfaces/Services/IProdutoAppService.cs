using Soft.Application.Interfaces;
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
    public interface IProdutoAppService : IRegisterAppService<ProdutoViewModel>
    {
        /// <summary>
        /// Find produto by id
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        ProdutoViewModel FindById(Int64 pro_id);

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProdutoViewModel> All();
    }
}