using Soft.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces.Validations
{
    public interface IVendedorValidation
    {
        ValidationReturn CheckVen_nomeIsNullOrEmpty(string ven_nome);
        ValidationReturn CheckVen_nomeThereAreOtherEqual(Int64 ven_id, string ven_nome);
        ValidationReturn CheckVen_nomeRegistered(Int64 ven_id);
        ValidationReturn CheckVen_inativo(Int64 ven_id);
    }
}