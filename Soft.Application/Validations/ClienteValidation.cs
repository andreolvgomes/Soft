using Soft.Application.Interfaces.Validations;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Validations
{
    public class ClienteValidation : IClienteValidation
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteValidation(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ValidationReturn CheckCli_nomeThereAreOtherEqual(long cli_id, string cli_nome)
        {
            Cliente cliente = _clienteRepository.Find(new { Cli_nome = cli_nome }, s => new { s.Cli_id });
            if (cliente == null)
                return new ValidationReturn();
            if (cli_id != cliente.Cli_id)
                return new ValidationReturn("Cliente já existe cadastrado");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCli_inativo(long cli_id)
        {
            if (_clienteRepository.Find(new { Cli_id = cli_id }, s => new { s.Cli_inativo }).Cli_inativo)
                return new ValidationReturn("Cliente consta como inativo");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCli_nomeIsNullOrEmpty(string cli_nome)
        {
            if (cli_nome.NullOrEmpty())
                return new ValidationReturn("Informe o nome do Cliente");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCli_nomeRegistered(string cli_nome)
        {
            if (!_clienteRepository.Exists(new { Cli_nome = cli_nome }))
                return new ValidationReturn("Cliente não cadastrado");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCli_nomeRegistered(long cli_id)
        {
            if (!_clienteRepository.Exists(new { Cli_id = cli_id }))
                return new ValidationReturn("Cliente não cadastrado");
            return new ValidationReturn();
        }
    }
}