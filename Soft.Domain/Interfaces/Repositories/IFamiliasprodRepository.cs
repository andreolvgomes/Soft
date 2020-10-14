using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Interfaces.Repositories
{
    public interface IFamiliasprodRepository : IRepository<Familiasprod>
    {
        /// <summary>
        /// Get id by descrition Fam_descricao
        /// </summary>
        /// <param name="fam_descricao"></param>
        /// <returns></returns>
        Int64 GetFam_idByFam_descricao(string fam_descricao);
    }
}
