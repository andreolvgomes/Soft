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
    public class SubcategoriaRepository : Repository<Subcategoria>, ISubcategoriaRepository
    {
        public long GetSub_idBySub_descricao(string sub_descricao)
        {
            return Value<Int64>(new { Sub_descricao = sub_descricao }, s => new { s.Sub_id });
        }
    }
}
