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
    /// ClientesController
    /// </summary>
    public class ClientesController : ControllerRegister<ClienteViewModel>
    {
        private IClienteAppService _clienteAppService;
        private IClienteValidation _clienteValidation;

        /// <summary>
        /// Constructor ClientesController
        /// </summary>
        /// <param name="clienteAppService"></param>
        /// <param name="clienteValidation"></param>
        public ClientesController(IClienteAppService clienteAppService,
            IClienteValidation clienteValidation)
            : base(clienteAppService)
        {
            _clienteAppService = clienteAppService;
            _clienteValidation = clienteValidation;
        }

        /// <summary>
        /// Check cli_nome if Ok
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidCliente()
        {
            ValidationReturn valid = _clienteValidation.CheckCli_nomeIsNullOrEmpty(Entity.Cli_nome);
            if (!valid.Valid) return valid;

            valid = _clienteValidation.CheckCli_nomeThereAreOtherEqual(Entity.Cli_id, Entity.Cli_nome);
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }
    }
}