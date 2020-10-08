using Soft.Application.Interfaces.Validations;
using Soft.Domain.Extensions;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Validations
{
    public class FamiliasprodValidation : IFamiliasprodValidation
    {
        private readonly IFamiliasprodRepository _familiasprodRepository;

        public FamiliasprodValidation(IFamiliasprodRepository familiasprodRepository)
        {
            _familiasprodRepository = familiasprodRepository;
        }

        public ValidationReturn ValidFam_descricaoIsNullOrEmpty(string fam_descricao)
        {
            if (fam_descricao.NullOrEmpty())
                return new ValidationReturn("A descrição da família de produtos não pode ser vazia");
            return new ValidationReturn();
        }

        public ValidationReturn ValidFam_descricaoRegistered(string fam_descricao)
        {
            Familiasprod fam = _familiasprodRepository.Find(new { Fam_descricao = fam_descricao }, s => new { s.Fam_inativo });
            if (fam == null)
                return new ValidationReturn("Família de produtos não cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn ValidFam_descricaoRegistered(long fam_id)
        {
            Familiasprod fam = _familiasprodRepository.Find(new { Fam_id = fam_id }, s => new { s.Fam_inativo });
            if (fam == null)
                return new ValidationReturn("Família de produtos não cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn ValidFam_descricaoThereAreOtherEqual(long fam_id, string fam_descricao)
        {
            Familiasprod fam = _familiasprodRepository.Find(new { Fam_descricao = fam_descricao }, s => new { s.Fam_inativo });
            if (fam == null)
                return new ValidationReturn();
            if (fam.Fam_id != fam_id)
                return new ValidationReturn("Família de produtos já cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn ValidFam_inativo(long fam_id)
        {
            Familiasprod fam = _familiasprodRepository.Find(new { Fam_id = fam_id }, s => new { s.Fam_inativo });
            if (fam.Fam_inativo)
                return new ValidationReturn("Família de produtos consta como inativa");
            return new ValidationReturn();
        }
    }
}
