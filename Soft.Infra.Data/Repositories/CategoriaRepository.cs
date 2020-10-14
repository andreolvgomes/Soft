using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Infra.Data.Repositories
{
    /// <summary>
    /// Repository of Clientes
    /// </summary>
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public long GetCat_idByCat_descricao(string cat_descricao)
        {
            return Value<Int64>(new { Cat_descricao = cat_descricao }, s => new { s.Cat_id });
        }
    }
}