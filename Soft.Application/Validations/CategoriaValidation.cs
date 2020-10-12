using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soft.Application.Interfaces.Validations;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;

namespace Soft.Application.Validations
{
    public class CategoriaValidation : ICategoriaValidation
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaValidation(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ValidationReturn CheckCat_descricaoIsNullOrEmpty(string cat_descricao)
        {
            if (cat_descricao.NullOrEmpty())
                return new ValidationReturn("Descrição da Categoria não pode ser vazia");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCat_descricaoRegistered(string cat_descricao)
        {
            Categoria cat = _categoriaRepository.Find(new { Cat_descricao = cat_descricao }, s => new { s.Cat_id });
            if (cat == null)
                return new ValidationReturn("Categoria não cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCat_descricaoRegistered(long cat_id)
        {
            Categoria cat = _categoriaRepository.Find(new { Cat_id = cat_id }, s => new { s.Cat_id });
            if (cat == null)
                return new ValidationReturn("Categoria não cadastrada");
            return new ValidationReturn();
        }

        public ValidationReturn CheckCat_descricaoThereAreOtherEqual(long cat_id, string cat_descricao)
        {
            Categoria cat = _categoriaRepository.Find(new { Cat_descricao = cat_descricao }, s => new { s.Cat_id });

            // is null, so there is no other with the same name
            if (cat == null)
                return new ValidationReturn();

            if (cat_id != cat.Cat_id)
                return new ValidationReturn("Categoria já existe cadastrada");

            return new ValidationReturn();
        }

        public ValidationReturn CheckCat_inativo(long cat_id)
        {
            Categoria cat = _categoriaRepository.Find(new { Cat_id = cat_id }, s => new { s.Cat_id });
            if (cat.Cat_inativo)
                return new ValidationReturn("Categoria consta como inativa");
            return new ValidationReturn();
        }
    }
}