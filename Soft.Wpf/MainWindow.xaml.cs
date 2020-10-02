using Soft.Application.Interfaces;
using Soft.Application.Services;
using Soft.Infra.IoC;
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
    public partial class MainWindow : Window
    {
        private IProdutosAppService produtosAppService = null;

        public MainWindow()
        {
            InitializeComponent();
            produtosAppService = Ioc.Instance.GetInstance<IProdutosAppService>();
        }
    }
}
