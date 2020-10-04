using AutoMapper;
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
    public class ProdutoAppService : IProdutoAppService//IBaseAppService<Produtos>, IProdutosAppService
    {
        private readonly IProdutosRepository _produtosRepository = null;
        private readonly IMapper _mapper = null;

        public ProdutoAppService(IMapper mapper, IProdutosRepository produtosRepository)
        {
            _mapper = mapper;
            _produtosRepository = produtosRepository;
        }

        public void Create(ProdutoViewModel produtos)
        {
            _produtosRepository.Insert(_mapper.Map<Produto>(produtos));
        }

        public void Remove(long pro_id)
        {

        }

        public ProdutoViewModel FindById(long pro_id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtosRepository.Find(new { Pro_id = pro_id }));
        }

        public void Update(ProdutoViewModel produtos)
        {
            _produtosRepository.Update(_mapper.Map<Produto>(produtos));
        }

        public IEnumerable<ProdutoViewModel> All()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtosRepository.All());
        }

        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}
    }
}