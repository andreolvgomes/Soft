using Soft.Application.Interfaces;
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

        public void Create(Produtos produtos)
        {

        }

        public void Delete(long pro_id)
        {

        }

        public Produtos FindById(long pro_id)
        {
            return _produtosRepository.Find(new { Pro_id = pro_id });
        }
    }
}