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
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository = null;
        private readonly IMapper _mapper = null;

        public CategoriaAppService(IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        public long Insert(CategoriaViewModel viewModel, IDbTransaction transaction = null)
        {
            return _categoriaRepository.Insert(_mapper.Map<Categoria>(viewModel));
        }

        public int Update(CategoriaViewModel viewModel, Expression<Func<CategoriaViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _categoriaRepository.Update(_mapper.Map<Categoria>(viewModel), transaction: transaction);
        }

        public int Delete(CategoriaViewModel viewModel, IDbTransaction transaction = null)
        {
            return _categoriaRepository.Delete(_mapper.Map<Categoria>(viewModel), transaction: transaction);
        }

        public CategoriaViewModel Find(object param = null, Expression<Func<CategoriaViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaRepository.Find(param: param, selector:
                _mapper.Map<Expression<Func<Categoria, object>>>(selector), transaction: transaction));
        }

        public CategoriaViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _categoriaRepository.Count(param: param, transaction: transaction);
        }

        public IEnumerable<CategoriaViewModel> All(object param = null, Expression<Func<CategoriaViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.All(param: param,
                selector: _mapper.Map<Expression<Func<Categoria, object>>>(selector), transaction: transaction));
        }

        public long GetCat_idByCat_descricao(string cat_descricao)
        {
            return _categoriaRepository.GetCat_idByCat_descricao(cat_descricao);
        }
    }
}