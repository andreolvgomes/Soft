using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Interfaces.Repositories
{
    public interface ISubcategoriaRepository : IRepository<Subcategoria>
    {
        /// <summary>
        /// Get id by description from Sub_descricao
        /// </summary>
        /// <param name="sub_descricao"></param>
        /// <returns></returns>
        Int64 GetSub_idBySub_descricao(string sub_descricao);
    }
}