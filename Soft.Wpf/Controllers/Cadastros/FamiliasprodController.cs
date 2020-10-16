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
    public class FamiliasprodController : ControllerRegister<FamiliasprodViewModel>
    {
        private readonly IFamiliasprodAppService _familiasprodAppService;
        private readonly IFamiliasprodValidation _familiasprodValidation;

        /// <summary>
        /// Construtor of the FamiliasprodController
        /// </summary>
        /// <param name="familiasprodAppService"></param>
        /// <param name="familiasprodValidation"></param>
        public FamiliasprodController(IFamiliasprodAppService familiasprodAppService,
            IFamiliasprodValidation familiasprodValidation) : base(familiasprodAppService)
        {
            _familiasprodAppService = familiasprodAppService;
            _familiasprodValidation = familiasprodValidation;
        }

        /// <summary>
        /// Valid description
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidFam_descricao()
        {
            ValidationReturn valid = _familiasprodValidation.CheckFam_descricaoIsNullOrEmpty(Entity.Fam_descricao);
            if (!valid.Valid) return valid;

            valid = _familiasprodValidation.CheckFam_descricaoThereAreOtherEqual(Entity.Fam_id, Entity.Fam_descricao);
            if (!valid.Valid) return valid;
            return new ValidationReturn();
        }
    }
}