using Soft.Application.Interfaces.Services;
using Soft.Application.Interfaces.Validations;
using Soft.Application.Services;
using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Infra.IoC;
using Soft.Wpf.Controllers;
using Soft.Wpf.Controllers.Cadastros;
using Soft.Wpf.Views.Cadastros;
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

namespace Soft.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void CadProdutos_Click(object sender, RoutedEventArgs e)
        {
            Produtos pro = new Produtos();
            pro.ShowDialog();
        }

        private void CadFamilia_Click(object sender, RoutedEventArgs e)
        {
            Familiasprod pro = new Familiasprod();
            pro.ShowDialog();
        }

        private void CadSubCategorias_Click(object sender, RoutedEventArgs e)
        {
            SubCategorias pro = new SubCategorias();
            pro.ShowDialog();
        }

        private void CadCategorias_Click(object sender, RoutedEventArgs e)
        {
            Categorias pro = new Categorias();
            pro.ShowDialog();
        }
    }
}