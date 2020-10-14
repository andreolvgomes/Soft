using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Validations;

namespace Soft.Application.Interfaces.Validations
{
    /// <summary>
    /// Validations Subcategorias
    /// </summary>
    public interface ISubcategoriaValidation
    {
        /// <summary>
        /// Check if Sub_descricao is null or empty
        /// </summary>
        /// <param name="sub_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckSub_descricaoIsNullOrEmpty(string sub_descricao);

        /// <summary>
        /// Check if Sub_descricao is registered
        /// </summary>
        /// <param name="sub_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckSub_descricaoRegistered(string sub_descricao);

        /// <summary>
        /// Check if Sub_descricao is registered
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        ValidationReturn CheckSub_descricaoRegistered(Int64 sub_id);

        /// <summary>
        /// Check if there is other Sub_descricao equal
        /// </summary>
        /// <param name="sub_id"></param>
        /// <param name="sub_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckSub_descricaoThereAreOtherEqual(Int64 sub_id, string sub_descricao);

        /// <summary>
        /// Make sure the Subcategoria it is active
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        ValidationReturn CheckSub_inativo(Int64 sub_id);
    }
}