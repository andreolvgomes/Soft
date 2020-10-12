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
        ValidationReturn CheckPro_codigoIsNullOrEmpty(string pro_codigo);

        /// <summary>
        /// Validate pro_codigo
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_codigoRegistered(string pro_codigo);
        ValidationReturn CheckPro_codigoRegistered(Int64 pro_id);
        /// <summary>
        /// Validate if product to be ativ
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_inativo(string pro_codigo);
        /// <summary>
        /// Check if there are another pro_codigo equal in the database
        /// </summary>
        /// <param name="pro_id"></param>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_codigoThereAreOtherEqual(Int64 pro_id, string pro_codigo);

        ValidationReturn CheckPro_descricaoIsNullOrEmpty(string pro_descricao);
        /// <summary>
        /// Check if there are another pro_descricao equal in the database
        /// </summary>
        /// <param name="pro_id"></param>
        /// <param name="pro_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_descricaoThereAreOtherEqual(Int64 pro_id, string pro_descricao);
        /// <summary>
        /// Validate pro_pvenda of the product register
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_pvenda(string pro_codigo);
        /// <summary>
        /// Check if can sell fractioned
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        ValidationReturn CheckPro_fracionado(string pro_codigo);
    }
}