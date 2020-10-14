using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        /// <summary>
        /// Get id by description Cat_descricao
        /// </summary>
        /// <param name="cat_descricao"></param>
        /// <returns></returns>
        Int64 GetCat_idByCat_descricao(string cat_descricao);
    }
}