using Soft.Application.Interfaces;
using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Services
{
    public class ProdutosAppService : IProdutosAppService//IBaseAppService<Produtos>, IProdutosAppService
    {
        private readonly IProdutosRepository _produtosRepository = null;

        public ProdutosAppService(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public void Create(ProdutosViewModel produtos)
        {
            _produtosRepository.Insert(new Produtos()
            {
                Pro_codigo = produtos.Pro_codigo,
                Pro_descricao = produtos.Pro_descricao
            });
        }

        public void Remove(long pro_id)
        {

        }

        public ProdutosViewModel FindById(long pro_id)
        {
            Produtos produto = _produtosRepository.Find(new { Pro_id = pro_id });
            if (produto == null) return null;

            return new ProdutosViewModel()
            {
                Pro_id = produto.Pro_id,
                Pro_codigo = produto.Pro_codigo,
                Pro_descricao = produto.Pro_descricao
            };
        }

        public void Update(ProdutosViewModel produtos)
        {
            _produtosRepository.Update(new Produtos()
            {
                Pro_id = produtos.Pro_id,
                Pro_codigo = produtos.Pro_codigo,
                Pro_descricao = produtos.Pro_descricao
            });
        }
    }
}
