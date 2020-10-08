using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Validations;

namespace Soft.Application.Interfaces.Validations
{
    public interface IFamiliasprodValidation
    {
        ValidationReturn ValidFam_descricaoIsNullOrEmpty(string fam_descricao);
        ValidationReturn ValidFam_descricaoRegistered(string fam_descricao);
        ValidationReturn ValidFam_descricaoRegistered(Int64 fam_id);
        ValidationReturn ValidFam_descricaoThereAreOtherEqual(long fam_id, string fam_descricao);
        ValidationReturn ValidFam_inativo(Int64 fam_id);
    }
}