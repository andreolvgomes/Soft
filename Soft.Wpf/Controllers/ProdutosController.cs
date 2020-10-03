using Soft.Application.Interfaces;
using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
using Soft.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Soft.Wpf.Controllers
{
    public class ProdutosController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ProdutosViewModel _Produto;

        public ProdutosViewModel Produto
        {
            get { return _Produto; }
            set
            {
                if (_Produto != value)
                {
                    _Produto = value;
                    OnPropertyChanged("Produto");
                }
            }
        }

        private readonly IProdutosAppService _produtosAppService;
        private readonly IProdutosValidation _produtosValidation;

        public ProdutosController(IProdutosAppService produtosAppService, IProdutosValidation produtosValidation)
        {
            _produtosAppService = produtosAppService;
            _produtosValidation = produtosValidation;

            this.Produto = new ProdutosViewModel();
        }

        internal void Register()
        {
            if (Produto.Pro_id > 0)
                _produtosAppService.Update(Produto);
            else
                _produtosAppService.Create(Produto);
        }

        internal void Find()
        {
            ProdutosViewModel find = _produtosAppService.FindById(Produto.Pro_id);
            if (find == null)
                Produto = new ProdutosViewModel();
            else
                Produto = find;
        }

        public ValidationReturn ValidPro_codigo()
        {
            return _produtosValidation.ValidPro_codigoThereAreOtherEqual(Produto.Pro_id, Produto.Pro_codigo);
        }

        public ValidationReturn ValidPro_descricao()
        {
            return _produtosValidation.ValidPro_descricaoThereAreOtherEqual(Produto.Pro_id, Produto.Pro_descricao);
        }
    }
}