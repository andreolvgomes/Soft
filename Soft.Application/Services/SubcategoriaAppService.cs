using AutoMapper;
using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Services
{
    public class SubcategoriaAppService : ISubcategoriaAppService
    {
        private readonly ISubcategoriaRepository _subcategoriaRepository = null;
        private readonly IMapper _mapper = null;

        public SubcategoriaAppService(IMapper mapper, ISubcategoriaRepository subcategoriaRepository)
        {
            _mapper = mapper;
            _subcategoriaRepository = subcategoriaRepository;
        }

        public long Insert(SubcategoriaViewModel viewModel, IDbTransaction transaction = null)
        {
            return _subcategoriaRepository.Insert(_mapper.Map<Subcategoria>(viewModel));
        }

        public int Update(SubcategoriaViewModel viewModel, Expression<Func<SubcategoriaViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _subcategoriaRepository.Update(_mapper.Map<Subcategoria>(viewModel), transaction: transaction);
        }

        public int Delete(SubcategoriaViewModel viewModel, IDbTransaction transaction = null)
        {
            return _subcategoriaRepository.Delete(_mapper.Map<Subcategoria>(viewModel), transaction: transaction);
        }

        public SubcategoriaViewModel Find(object param = null, Expression<Func<SubcategoriaViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<SubcategoriaViewModel>(_subcategoriaRepository.Find(param: param, selector:
                _mapper.Map<Expression<Func<Subcategoria, object>>>(selector), transaction: transaction));
        }

        public SubcategoriaViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<SubcategoriaViewModel>(_subcategoriaRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _subcategoriaRepository.Count(param: param, transaction: transaction);
        }

        public IEnumerable<SubcategoriaViewModel> All(object param = null, Expression<Func<SubcategoriaViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<IEnumerable<SubcategoriaViewModel>>(_subcategoriaRepository.All(param: param,
                selector: _mapper.Map<Expression<Func<Subcategoria, object>>>(selector), transaction: transaction));
        }

        public long GetSub_idBySub_descricao(string sub_descricao)
        {
            return _subcategoriaRepository.Value<Int64>(new { Sub_descricao = sub_descricao }, s => new { s.Sub_id });
        }
    }
}