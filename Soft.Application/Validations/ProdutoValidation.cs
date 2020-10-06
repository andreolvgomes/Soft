using Soft.Application.Interfaces.Validations;
using Soft.Domain.Extensions;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Validations
{
    public class ProdutoValidation : IProdutoValidation
    {
        private readonly IProdutosRepository _produtosRepository = null;

        public ProdutoValidation(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public ValidationReturn ValidPro_codigo(string pro_codigo)
        {
            if (pro_codigo.NullOrEmpty())
                return new ValidationReturn("Código do produto não pode ser vazio");

            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_inativo });
            if (produto == null)
                return new ValidationReturn("Produto não cadastrado");

            if (produto.Pro_inativo)
                return new ValidationReturn("Produto consta como inativo");

            return new ValidationReturn();
        }

        public ValidationReturn ValidPro_codigoThereAreOtherEqual(Int64 pro_id, string pro_codigo)
        {
            if (pro_codigo.NullOrEmpty())
                return new ValidationReturn("Código do produto não pode ser vazio");

            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_descricao, s.Pro_id });
            // is null, there are no other
            if (produto == null)
                return new ValidationReturn();

            if (produto.Pro_id != pro_id)
                return new ValidationReturn("Já existe outro produto com o mesmo código");

            return new ValidationReturn();
        }

        public ValidationReturn ValidPro_descricaoThereAreOtherEqual(Int64 pro_id, string pro_descricao)
        {
            if (pro_descricao.NullOrEmpty())
                return new ValidationReturn("Descrição do Produto não pode ser vazia");

            Produto produto = _produtosRepository.Find(new { Pro_descricao = pro_descricao },
                s => new { s.Pro_descricao, s.Pro_id });

            // is null, there are no other
            if (produto == null)
                return new ValidationReturn();

            if (produto.Pro_id != pro_id)
                return new ValidationReturn("Já existe outro produto com a mesma descrição");

            return new ValidationReturn();
        }

        public ValidationReturn ValidPro_fracionado(string pro_codigo)
        {
            throw new NotImplementedException();
        }

        public ValidationReturn ValidPro_pvenda(string pro_codigo)
        {
            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_pvenda });
            if (produto.Pro_pvenda < 0)
                return new ValidationReturn("Preço de venda do produto não pode ser zerado");
            return new ValidationReturn();
        }
    }
}