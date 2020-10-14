using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Validations;

namespace Soft.Application.Interfaces.Validations
{
    /// <summary>
    /// Validations Categorias
    /// </summary>
    public interface ICategoriaValidation
    {
        /// <summary>
        /// Check if there is other Cat_descricao registered equal
        /// </summary>
        /// <param name="cat_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckCat_descricaoRegistered(string cat_descricao);

        /// <summary>
        /// Check if there is other Cat_descricao registered equal
        /// </summary>
        /// <param name="cat_id"></param>
        /// <returns></returns>
        ValidationReturn CheckCat_descricaoRegistered(Int64 cat_id);

        /// <summary>
        /// Check if Cat_descricao is null or empty
        /// </summary>
        /// <param name="cat_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckCat_descricaoIsNullOrEmpty(string cat_descricao);

        /// <summary>
        /// Check if there is other Cat_descricao registered equal
        /// </summary>
        /// <param name="cat_id"></param>
        /// <param name="cat_descricao"></param>
        /// <returns></returns>
        ValidationReturn CheckCat_descricaoThereAreOtherEqual(Int64 cat_id, string cat_descricao);

        /// <summary>
        /// Make sure the Categoria it is active
        /// </summary>
        /// <param name="cat_id"></param>
        /// <returns></returns>
        ValidationReturn CheckCat_inativo(Int64 cat_id);
    }
}