using Soft.Application.Interfaces;
using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Wpf.Controllers.Cadastros.Core;
using Soft.Wpf.Delegates;
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
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ISubcategoriaAppService _subcategoriaAppService;
        private readonly IFamiliasprodAppService _familiasprodAppService;

        private readonly IProdutoValidation _produtosValidation;

        public ProdutosController(IProdutoAppService produtosAppService,
            ICategoriaAppService categoriaAppService,
            ISubcategoriaAppService subcategoriaAppService,
            IFamiliasprodAppService familiasprodAppService,
            IProdutoValidation produtosValidation) : base(produtosAppService)
        {
            _produtosAppService = produtosAppService;
            _categoriaAppService = categoriaAppService;
            _subcategoriaAppService = subcategoriaAppService;
            _familiasprodAppService = familiasprodAppService;

            _produtosValidation = produtosValidation;

            this.EventTreatToDatabase += new RegisterTreatEventHandler<ProdutoViewModel>(TreatToDatabase);
        }

        private void TreatToDatabase(ProdutoViewModel viewmodel)
        {
            CategoriaViewModel categoria = _categoriaAppService.Find();
            if (categoria == null)
            {
                viewmodel.Cat_id = _categoriaAppService.Insert(new CategoriaViewModel() { Cat_descricao = "CATEGORIA PADRAO" });
                categoria = _categoriaAppService.Find();
            }
            viewmodel.Cat_id = categoria.Cat_id;

            SubcategoriaViewModel subcategoria = _subcategoriaAppService.Find();
            if (subcategoria == null)
            {
                viewmodel.Sub_id = _subcategoriaAppService.Insert(new SubcategoriaViewModel() { Sub_descricao = "SUBCATEGORIA PADRAO" });
                subcategoria = _subcategoriaAppService.Find();
            }
            viewmodel.Sub_id = subcategoria.Sub_id;

            FamiliasprodViewModel familiaprod = _familiasprodAppService.Find();
            if (familiaprod == null)
            {
                viewmodel.Fam_id = _familiasprodAppService.Insert(new FamiliasprodViewModel() { Fam_descricao = "FAMILIA PADRAO" });
                familiaprod = _familiasprodAppService.Find();
            }
            viewmodel.Fam_id = familiaprod.Fam_id;
        }

        public ValidationReturn ValidPro_codigo()
        {
            return _produtosValidation.ValidPro_codigoThereAreOtherEqual(Entity.Pro_id, Entity.Pro_codigo);
        }

        public ValidationReturn ValidPro_descricao()
        {
            return _produtosValidation.ValidPro_descricaoThereAreOtherEqual(Entity.Pro_id, Entity.Pro_descricao);
        }
    }
}