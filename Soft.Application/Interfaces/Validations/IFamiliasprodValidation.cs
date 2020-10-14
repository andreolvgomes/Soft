using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Validations;

namespace Soft.Application.Interfaces.Validations
{
    /// <summary>
    /// Validations Familiasprod
    /// </summary>
    public interface IFamiliasprodValidation
    {
        /// <summary>
        /// Check if Fam_descricao is null or empty
        /// </summary>
        /// <param name="fam_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckFam_descricaoIsNullOrEmpty(string fam_descricao);

        /// <summary>
        /// Check if Fam_descricao is registered
        /// </summary>
        /// <param name="fam_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckFam_descricaoRegistered(string fam_descricao);

        /// <summary>
        /// Check if Fam_descricao is registered
        /// </summary>
        /// <param name="fam_id"></param>
        /// <returns></returns>
        ValidationReturn CheckFam_descricaoRegistered(Int64 fam_id);

        /// <summary>
        /// Check if there are other Fam_descricao equal
        /// </summary>
        /// <param name="fam_id"></param>
        /// <param name="fam_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckFam_descricaoThereAreOtherEqual(long fam_id, string fam_descricao);

        /// <summary>
        /// Make sure the Familiaprod it is active
        /// </summary>
        /// <param name="fam_id"></param>
        /// <returns></returns>
        ValidationReturn CheckFam_inativo(Int64 fam_id);
    }
}