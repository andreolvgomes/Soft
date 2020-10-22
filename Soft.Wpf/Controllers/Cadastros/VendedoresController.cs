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
    public class VendedoresController : ControllerRegister<VendedorViewModel>
    {
        private readonly IVendedorAppService _vendedorAppService;
        private readonly IVendedorValidation _vendedorValidation;

        public VendedoresController(IVendedorAppService vendedorAppService,
            IVendedorValidation vendedorValidation)
            : base(vendedorAppService)
        {
            _vendedorAppService = vendedorAppService;
            _vendedorValidation = vendedorValidation;
        }

        public ValidationReturn ValidVen_nome()
        {
            ValidationReturn valid = _vendedorValidation.CheckVen_nomeIsNullOrEmpty(Entity.Ven_nome);
            if (!valid.Valid) return valid;

            valid = _vendedorValidation.CheckVen_nomeThereAreOtherEqual(Entity.Ven_id, Entity.Ven_nome);
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }
    }
}
