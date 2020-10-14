using Soft.Application.Validations;
using Soft.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces.Validations
{
    /// <summary>
    /// Interface of validation produto
    /// </summary>
    public interface IProdutoValidation
    {
        /// <summary>
        /// Check if Pro_codigo is null or empty
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_codigoIsNullOrEmpty(string pro_codigo);

        /// <summary>
        /// Check if Pro_codigo is registered
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_codigoRegistered(string pro_codigo);

        /// <summary>
        /// Check is Pro_codigo is registered
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_codigoRegistered(Int64 pro_id);

        /// <summary>
        /// Make sure the product it is active
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_inativo(string pro_codigo);

        /// <summary>
        /// Check if there is another pro_codigo equal in the database
        /// </summary>
        /// <param name="pro_id"></param>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_codigoThereAreOtherEqual(Int64 pro_id, string pro_codigo);

        /// <summary>
        /// Check if Pro_descricao is null or empty
        /// </summary>
        /// <param name="pro_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_descricaoIsNullOrEmpty(string pro_descricao);

        /// <summary>
        /// Check if there is another pro_descricao equal in the database
        /// </summary>
        /// <param name="pro_id"></param>
        /// <param name="pro_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_descricaoThereAreOtherEqual(Int64 pro_id, string pro_descricao);

        /// <summary>
        /// Check if Pro_pvenda is zero
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_pvenda(string pro_codigo);
    }
}