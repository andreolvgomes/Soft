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
    public interface IProdutoAppService //: IDisposable//: IBaseAppService<Produtos>
    {
        /// <summary>
        /// Create new produto into database
        /// </summary>
        /// <param name="produtoViewModel"></param>
        void Create(ProdutoViewModel produtoViewModel);
        /// <summary>
        /// Update produto in the database
        /// </summary>
        /// <param name="produtoViewModel"></param>
        void Update(ProdutoViewModel produtoViewModel);
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
        ProdutoViewModel FindById(Int64 pro_id);

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProdutoViewModel> All();
    }
}
