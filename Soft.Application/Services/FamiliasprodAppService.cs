﻿using AutoMapper;
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
    public class FamiliasprodAppService : IFamiliasprodAppService
    {
        private readonly IFamiliasprodRepository _familiasprodRepository = null;
        private readonly IMapper _mapper = null;

        public FamiliasprodAppService(IMapper mapper, IFamiliasprodRepository familiasprodRepository)
        {
            _mapper = mapper;
            this._familiasprodRepository = familiasprodRepository;
        }

        public long Insert(FamiliasprodViewModel viewModel, IDbTransaction transaction = null)
        {
            return _familiasprodRepository.Insert(_mapper.Map<Familiasprod>(viewModel));
        }

        public int Update(FamiliasprodViewModel viewModel, Expression<Func<FamiliasprodViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _familiasprodRepository.Update(_mapper.Map<Familiasprod>(viewModel), transaction: transaction);
        }

        public int Delete(FamiliasprodViewModel viewModel, IDbTransaction transaction = null)
        {
            return _familiasprodRepository.Delete(_mapper.Map<Familiasprod>(viewModel), transaction: transaction);
        }

        public FamiliasprodViewModel Find(object param = null, Expression<Func<FamiliasprodViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<FamiliasprodViewModel>(_familiasprodRepository.Find(param: param, selector:
                _mapper.Map<Expression<Func<Familiasprod, object>>>(selector), transaction: transaction));
        }

        public FamiliasprodViewModel FindOffset(int offset, object param = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<FamiliasprodViewModel>(_familiasprodRepository.FindOffset(offset, param: param, transaction: transaction));
        }

        public int Count(object param = null, IDbTransaction transaction = null)
        {
            return _familiasprodRepository.Count(param: param, transaction: transaction);
        }

        public IEnumerable<FamiliasprodViewModel> All(object param = null, Expression<Func<FamiliasprodViewModel, object>> selector = null, IDbTransaction transaction = null)
        {
            return _mapper.Map<IEnumerable<FamiliasprodViewModel>>(_familiasprodRepository.All(param: param,
                selector: _mapper.Map<Expression<Func<Familiasprod, object>>>(selector), transaction: transaction));
        }

        public long GetFam_idByFam_descricao(string fam_descricao)
        {
            return _familiasprodRepository.GetFam_idByFam_descricao(fam_descricao);
        }
    }
}