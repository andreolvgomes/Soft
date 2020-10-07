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
        private readonly IProdutoRepository _produtosRepository = null;

        /// <summary>
        /// ProdutoValidation
        /// </summary>
        /// <param name="produtosRepository"></param>
        public ProdutoValidation(IProdutoRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public ValidationReturn ValidPro_codigoIsNullOrEmpty(string pro_codigo)
        {
            if (pro_codigo.NullOrEmpty())
                return new ValidationReturn("Código do produto não pode ser vazio");
            return new ValidationReturn();
        }

        public ValidationReturn ValidPro_descricaoIsNullOrEmpty(string pro_descricao)
        {
            if (pro_descricao.NullOrEmpty())
                return new ValidationReturn("Descrição do produto não pode ser vazia");
            return new ValidationReturn();
        }

        /// <summary>
        /// Valida produto, verifica se existe cadastrado
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        public ValidationReturn ValidPro_codigoRegistered(string pro_codigo)
        {
            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_inativo });
            if (produto == null)
                return new ValidationReturn("Produto não cadastrado");

            return new ValidationReturn();
        }

        public ValidationReturn ValidPro_codigoRegistered(long pro_id)
        {
            Produto produto = _produtosRepository.Find(new { Pro_id = pro_id }, s => new { s.Pro_inativo });
            if (produto == null)
                return new ValidationReturn("Produto não cadastrado");

            return new ValidationReturn();
        }

        /// <summary>
        /// Valida se o produto está ativo
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        public ValidationReturn ValidPro_inativo(string pro_codigo)
        {
            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_inativo });
            if (produto.Pro_inativo)
                return new ValidationReturn("Produto consta como inativo");

            return new ValidationReturn();
        }

        /// <summary>
        /// Verifica se já existe outro produto cadastrado com o mesmo código
        /// </summary>
        /// <param name="pro_id"></param>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        public ValidationReturn ValidPro_codigoThereAreOtherEqual(Int64 pro_id, string pro_codigo)
        {
            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_descricao, s.Pro_id });
            // is null, there are no other
            if (produto == null)
                return new ValidationReturn();

            if (produto.Pro_id != pro_id)
                return new ValidationReturn("Produto já existe cadastrado");

            return new ValidationReturn();
        }

        /// <summary>
        /// Verifica se já existe outro produto cadastro com a mesma descrição
        /// </summary>
        /// <param name="pro_id"></param>
        /// <param name="pro_descricao"></param>
        /// <returns></returns>
        public ValidationReturn ValidPro_descricaoThereAreOtherEqual(Int64 pro_id, string pro_descricao)
        {
            Produto produto = _produtosRepository.Find(new { Pro_descricao = pro_descricao },
                s => new { s.Pro_descricao, s.Pro_id });

            // is null, there are no other
            if (produto == null)
                return new ValidationReturn();

            if (produto.Pro_id != pro_id)
                return new ValidationReturn("Produto já existe cadastrado");

            return new ValidationReturn();
        }

        /// <summary>
        /// Verifica se o produto pode ser vendido com quantidade fracionada
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        public ValidationReturn ValidPro_fracionado(string pro_codigo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica se o preço de venda do cadastro do produto está zerado
        /// </summary>
        /// <param name="pro_codigo"></param>
        /// <returns></returns>
        public ValidationReturn ValidPro_pvenda(string pro_codigo)
        {
            Produto produto = _produtosRepository.Find(new { Pro_codigo = pro_codigo }, s => new { s.Pro_pvenda });
            if (produto.Pro_pvenda < 0)
                return new ValidationReturn("Preço de venda do produto não pode ser zerado");
            return new ValidationReturn();
        }
    }
}