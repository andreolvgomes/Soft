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
        ValidationReturn CheckSub_descricaoIsNullOrEmpty(string sub_descricao);
        ValidationReturn CheckSub_descricaoRegistered(string sub_descricao);
        ValidationReturn CheckSub_descricaoRegistered(Int64 sub_id);
        ValidationReturn CheckSub_descricaoThereAreOtherEqual(Int64 sub_id, string sub_descricao);
        ValidationReturn CheckSub_inativo(Int64 sub_id);
    }
}