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
using System.Runtime.InteropServices;
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
        private readonly ICategoriaValidation _categoriaValidation;
        private readonly ISubcategoriaValidation _subcategoriaValidation;
        private readonly IFamiliasprodValidation _familiasprodValidation;

        public ProdutosController(IProdutoAppService produtosAppService,
            ICategoriaAppService categoriaAppService,
            ISubcategoriaAppService subcategoriaAppService,
            IFamiliasprodAppService familiasprodAppService,
            IProdutoValidation produtosValidation,
            ICategoriaValidation categoriaValidation,
            ISubcategoriaValidation subcategoriaValidation,
            IFamiliasprodValidation familiasprodValidation
            ) : base(produtosAppService)
        {
            _produtosAppService = produtosAppService;
            _categoriaAppService = categoriaAppService;
            _subcategoriaAppService = subcategoriaAppService;
            _familiasprodAppService = familiasprodAppService;

            _produtosValidation = produtosValidation;
            _categoriaValidation = categoriaValidation;
            _subcategoriaValidation = subcategoriaValidation;
            _familiasprodValidation = familiasprodValidation;

            this.EventTreatToDatabase += new RegisterTreatEventHandler<ProdutoViewModel>(TreatToDatabase);
            this.EventTreatToView += new RegisterTreatEventHandler<ProdutoViewModel>(TreatToView);
        }

        /// <summary>
        /// Prepara os dados para serem exibidos na View
        /// </summary>
        /// <param name="viewmodel"></param>
        private void TreatToView(ProdutoViewModel viewmodel)
        {
            CategoriaViewModel cat = _categoriaAppService.Find(new { Cat_id = viewmodel.Cat_id });
            viewmodel.Cat_descricaoView = cat.Cat_descricao;

            SubcategoriaViewModel sub = _subcategoriaAppService.Find(new { Sub_id = viewmodel.Sub_id });
            viewmodel.Sub_descricaoView = sub.Sub_descricao;

            FamiliasprodViewModel familiaprod = _familiasprodAppService.Find(new { Fam_id = viewmodel.Fam_id });
            viewmodel.Fam_descricaoView = familiaprod.Fam_descricao;
        }

        /// <summary>
        /// Prepara os dados para serem gravados na base de dados
        /// </summary>
        /// <param name="viewmodel"></param>
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

        /// <summary>
        /// Valida código do Produto
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidPro_codigo()
        {
            ValidationReturn valid = _produtosValidation.CheckPro_codigoIsNullOrEmpty(Entity.Pro_codigo);
            if (!valid.Valid) return valid;

            valid = _produtosValidation.CheckPro_codigoThereAreOtherEqual(Entity.Pro_id, Entity.Pro_codigo);
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }

        /// <summary>
        /// Valida descrição do Produto
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidPro_descricao()
        {
            ValidationReturn valid = _produtosValidation.CheckPro_codigoIsNullOrEmpty(Entity.Pro_descricao);
            if (!valid.Valid) return valid;
            
            valid = _produtosValidation.CheckPro_descricaoThereAreOtherEqual(Entity.Pro_id, Entity.Pro_descricao);
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }

        /// <summary>
        /// Valida Categoria
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidCategoria()
        {
            // check if textbox is null or empty
            ValidationReturn valid = _categoriaValidation.CheckCat_descricaoIsNullOrEmpty(Entity.Cat_descricaoView);
            if (!valid.Valid) return valid;

            // check if exists
            valid = _categoriaValidation.CheckCat_descricaoRegistered(Entity.Cat_descricaoView);
            if (!valid.Valid) return valid;

            // check if to be ativ
            valid = _categoriaValidation.CheckCat_inativo(_categoriaAppService.GetCat_idByCat_descricao(Entity.Cat_descricaoView));
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }

        /// <summary>
        /// Valida Subcategoria
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidSubcategoria()
        {
            ValidationReturn valid = _subcategoriaValidation.CheckSub_descricaoIsNullOrEmpty(Entity.Sub_descricaoView);
            if (!valid.Valid) return valid;

            valid = _subcategoriaValidation.CheckSub_descricaoRegistered(_subcategoriaAppService.GetSub_idBySub_descricao(Entity.Sub_descricaoView));
            if (!valid.Valid) return valid;

            valid = _subcategoriaValidation.CheckSub_inativo(_subcategoriaAppService.GetSub_idBySub_descricao(Entity.Sub_descricaoView));
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }

        /// <summary>
        /// Valida Familiapro
        /// </summary>
        /// <returns></returns>
        public ValidationReturn ValidFamiliaprod()
        {
            ValidationReturn valid = _familiasprodValidation.CheckFam_descricaoIsNullOrEmpty(Entity.Fam_descricaoView);
            if (!valid.Valid) return valid;

            valid = _familiasprodValidation.CheckFam_descricaoRegistered(Entity.Fam_descricaoView);
            if (!valid.Valid) return valid;

            valid = _familiasprodValidation.CheckFam_inativo(_familiasprodAppService.GetFam_idByFam_descricao(Entity.Fam_descricaoView));
            if (!valid.Valid) return valid;

            return new ValidationReturn();
        }
    }
}