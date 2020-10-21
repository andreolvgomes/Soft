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
    /// Controller
    /// </summary>
    public class SubCategoriasController : ControllerRegister<SubcategoriaViewModel>
    {
        private readonly ISubcategoriaValidation _subcategoriaValidation;

        /// <summary>
        /// Construtor of SubCategoriasController
        /// </summary>
        /// <param name="subcategoriaAppService"></param>
        /// <param name="subcategoriaValidation"></param>
        public SubCategoriasController(ISubcategoriaAppService subcategoriaAppService, 
            ISubcategoriaValidation subcategoriaValidation)
            : base(subcategoriaAppService)
        {
            _subcategoriaValidation = subcategoriaValidation;
        }

        /// <summary>
        /// Valid description
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidSub_descricao()
        {
            ValidationReturn valid = _subcategoriaValidation.CheckSub_descricaoIsNullOrEmpty(Entity.Sub_descricao);
            if (!valid.Valid) return valid;

            valid = _subcategoriaValidation.CheckSub_descricaoThereAreOtherEqual(Entity.Sub_id, Entity.Sub_descricao);
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }
    }
}
