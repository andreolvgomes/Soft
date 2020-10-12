using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Validations;

namespace Soft.Application.Interfaces.Validations
{
    public interface ICategoriaValidation
    {
        ValidationReturn CheckCat_descricaoRegistered(string cat_descricao);
        ValidationReturn CheckCat_descricaoRegistered(Int64 cat_id);
        ValidationReturn CheckCat_descricaoIsNullOrEmpty(string cat_descricao);
        ValidationReturn CheckCat_descricaoThereAreOtherEqual(Int64 cat_id, string cat_descricao);
        ValidationReturn CheckCat_inativo(Int64 cat_id);
    }
}