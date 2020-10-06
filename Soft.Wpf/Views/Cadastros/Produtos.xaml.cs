using Soft.Application.Validations;
using Soft.Infra.IoC;
using Soft.Wpf.Controllers.Cadastros;
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
            controller.Init();
            controller.Test();
            this.DataContext = controller;
            buttons.SetIActions(controller);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Valid())
            {
            }
        }

        private bool Valid()
        {
            if (!MessageValid(controller.ValidPro_codigo())) return false;
            if (!MessageValid(controller.ValidPro_descricao())) return false;
            return true;
        }

        private bool MessageValid(ValidationReturn result)
        {
            if (result.Valid) return true;
            MessageBox.Show(result.Message);
            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
