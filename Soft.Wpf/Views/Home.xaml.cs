using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Infra.IoC;
using Soft.Wpf.Controllers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Soft.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        private ProdutosController controller = null;

        public Home()
        {
            InitializeComponent();
            controller = Ioc.Instance.GetInstance<ProdutosController>();

            this.DataContext = controller;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Valid())
            {
                controller.Register();
                Find();
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

        private void Find()
        {
            controller.Find();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Find();
        }
    }
}