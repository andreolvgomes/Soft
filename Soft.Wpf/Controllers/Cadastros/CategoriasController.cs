using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Wpf.Controllers.Cadastros.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers.Cadastros
{
    /// <summary>
    /// Controller to View Categoria
    /// </summary>
    public class CategoriasController : ControllerRegister<CategoriaViewModel>
    {
        private readonly ICategoriaValidation _categoriaValidation;

        /// <summary>
        /// Constructor of Categorias Controller
        /// </summary>
        /// <param name="categoriaAppService"></param>
        /// <param name="categoriaValidation"></param>
        public CategoriasController(ICategoriaAppService categoriaAppService, 
            ICategoriaValidation categoriaValidation)
            : base(categoriaAppService)
        {
            _categoriaValidation = categoriaValidation;
        }

        /// <summary>
        /// Validate description
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidCat_descricao()
        {
            ValidationReturn valid = _categoriaValidation.CheckCat_descricaoIsNullOrEmpty(Entity.Cat_descricao);
            if (!valid.Valid) return valid;

            valid = _categoriaValidation.CheckCat_descricaoThereAreOtherEqual(Entity.Cat_id, Entity.Cat_descricao);
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }
    }
}