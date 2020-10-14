using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Infra.Data.Repositories
{
    public class FamiliasprodRepository : Repository<Familiasprod>, IFamiliasprodRepository
    {
        public long GetFam_idByFam_descricao(string fam_descricao)
        {
            return Value<Int64>(new { Fam_descricao = fam_descricao }, s => new { s.Fam_id });
        }
    }
}
