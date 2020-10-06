using Soft.Application.Interfaces;
using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Wpf.Controllers.Cadastros.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Soft.Wpf.Controllers.Cadastros
{
    public class ProdutosController : ControllerRegister<ProdutoViewModel>
    {
        private readonly IProdutoAppService _produtosAppService;
        private readonly IProdutoValidation _produtosValidation;

        public ProdutosController(IProdutoAppService produtosAppService, IProdutoValidation produtosValidation)
            : base(produtosAppService)
        {
            _produtosAppService = produtosAppService;
            _produtosValidation = produtosValidation;
        }

        public ValidationReturn ValidPro_codigo()
        {
            return _produtosValidation.ValidPro_codigoThereAreOtherEqual(Entidade.Pro_id, Entidade.Pro_codigo);
        }

        public ValidationReturn ValidPro_descricao()
        {
            return _produtosValidation.ValidPro_descricaoThereAreOtherEqual(Entidade.Pro_id, Entidade.Pro_descricao);
        }
    }
}