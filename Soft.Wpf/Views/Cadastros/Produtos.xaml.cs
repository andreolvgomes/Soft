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
        private ProdutosController controller = null;

        public Produtos()
        {
            InitializeComponent();
            
            controller = Ioc.Instance.GetInstance<ProdutosController>();
            controller.EventNewRegister += new RegisterNewEventHandler<ProdutoViewModel>(NewRecord);
            controller.EventValidation += new RegisterValidationEventHandler(IsValid);
            controller.Init();

            this.DataContext = controller;
            buttons.InjectActions(controller);
        }

        private bool IsValid()
        {
            if (!MessageValid(controller.ValidPro_codigo())) return false;
            if (!MessageValid(controller.ValidPro_descricao())) return false;
            if (!MessageValid(controller.ValidCategoria())) return false;
            if (!MessageValid(controller.ValidSubcategoria())) return false;
            return true;
        }

        private ProdutoViewModel NewRecord()
        {
            return new ProdutoViewModel();
        }

        private bool MessageValid(ValidationReturn result)
        {
            if (result.Valid) return true;
            MessageBox.Show(result.Message);
            return false;
        }
    }
}
