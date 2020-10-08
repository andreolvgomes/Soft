using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Validations;

namespace Soft.Application.Interfaces.Validations
{
    public interface ISubcategoriaValidation
    {
        ValidationReturn ValidSub_descricaoIsNullOrEmpty(string sub_descricao);
        ValidationReturn ValidSub_descricaoRegistered(string sub_descricao);
        ValidationReturn ValidSub_descricaoRegistered(Int64 sub_id);
        ValidationReturn ValidSub_descricaoThereAreOtherEqual(Int64 sub_id, string sub_descricao);
        ValidationReturn ValidSub_inativo(Int64 sub_id);
    }
}