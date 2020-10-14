using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Infra.IoC;
using Soft.Wpf.Controllers.Cadastros;
using Soft.Wpf.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Soft.Wpf.Views.Cadastros
{
    /// <summary>
    /// Interaction logic for Produtos.xaml
    /// </summary>
    public partial class Produtos : Window
    {
        /// <summary>
        /// Controller Produtos
        /// </summary>
        private ProdutosController controller = null;

        /// <summary>
        /// Constructor of view Produtos
        /// </summary>
        public Produtos()
        {
            InitializeComponent();
            
            controller = Ioc.Instance.GetInstance<ProdutosController>();
            controller.Init(buttons);
            this.DataContext = controller;

            // events
            controller.EventNewRegister += new RegisterNewEventHandler<ProdutoViewModel>(NewRecord);
            controller.EventValidation += new RegisterValidationEventHandler(IsValid);                        
        }

        /// <summary>
        /// Check validations
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (!MessageValid(controller.ValidPro_codigo())) return false;
            if (!MessageValid(controller.ValidPro_descricao())) return false;
            if (!MessageValid(controller.ValidCategoria())) return false;
            if (!MessageValid(controller.ValidSubcategoria())) return false;
            return true;
        }

        /// <summary>
        /// Execute new record
        /// </summary>
        /// <returns></returns>
        private ProdutoViewModel NewRecord()
        {
            ProdutoViewModel produto = new ProdutoViewModel();
            produto.Cat_descricaoView = "CATEGORIA PADRÃO";
            produto.Fam_descricaoView = "FAMÍLIA PADRÃO";
            produto.Sub_descricaoView = "SUBCATEGORIA PADRÃO";
            return produto;
        }

        /// <summary>
        /// Show message from validation
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool MessageValid(ValidationReturn result)
        {
            if (result.Valid) return true;
            MessageBox.Show(result.Message);
            return false;
        }
    }
}