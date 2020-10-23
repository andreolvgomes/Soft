using Soft.Infra.IoC;
using Soft.Wpf.Controllers;
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

namespace Soft.Wpf.Views.Pedidos
{
    /// <summary>
    /// Interaction logic for PedidoView.xaml
    /// </summary>
    public partial class PedidoView : Window
    {
        private PedidosController controller;

        public PedidoView()
        {
            InitializeComponent();
            controller = Ioc.Instance.GetInstance<PedidosController>();
            this.DataContext = controller;
        }
    }
}
