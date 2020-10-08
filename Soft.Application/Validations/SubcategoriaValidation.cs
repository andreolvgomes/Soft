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
    public class SubcategoriaValidation : ISubcategoriaValidation
    {
        private readonly ISubcategoriaRepository _subcategoriaRepository;

        public SubcategoriaValidation(ISubcategoriaRepository subcategoriaRepository)
        {
            _subcategoriaRepository = subcategoriaRepository;
        }

        public ValidationReturn ValidSub_descricaoIsNullOrEmpty(string sub_descricao)
        {
            if (sub_descricao.NullOrEmpty())
                return new ValidationReturn("Descrição da subcategoria não pode ser vazia");
            return new ValidationReturn();
        }

        public ValidationReturn ValidSub_descricaoRegistered(string sub_descricao)
        {
            Subcategoria sub = _subcategoriaRepository.Find(new { sub_descricao = sub_descricao }, s => new { s.Sub_id });
            if (sub == null)
                return new ValidationReturn("Subcategoria não cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn ValidSub_descricaoRegistered(long sub_id)
        {
            Subcategoria sub = _subcategoriaRepository.Find(new { Sub_id = sub_id }, s => new { s.Sub_id });
            if (sub == null)
                return new ValidationReturn("Subcategoria não cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn ValidSub_descricaoThereAreOtherEqual(Int64 sub_id, string sub_descricao)
        {
            Subcategoria sub = _subcategoriaRepository.Find(new { Sub_descricao = sub_descricao }, s => new { s.Sub_id });
            if (sub == null)
                return new ValidationReturn();
            if (sub.Sub_id != sub_id)
                return new ValidationReturn("Subcategoria já existe cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn ValidSub_inativo(long sub_id)
        {
            Subcategoria sub = _subcategoriaRepository.Find(new { Sub_id = sub_id }, s => new { s.Sub_inativo });
            if (sub.Sub_inativo)
                return new ValidationReturn("Subcategoria consta como inativa");
            return new ValidationReturn();
        }
    }
}
