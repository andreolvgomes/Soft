using Soft.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces.Validations
{
    public interface IClienteValidation
    {
        ValidationReturn CheckCli_nomeIsNullOrEmpty(string cli_nome);
        ValidationReturn CheckCli_nomeThereAreOtherEqual(Int64 cli_id, string cli_nome);
        ValidationReturn CheckCli_nomeRegistered(string cli_nome);
        ValidationReturn CheckCli_nomeRegistered(Int64 cli_id);
        ValidationReturn CheckCli_inativo(Int64 cli_id);
    }
}