using Soft.Wpf.Controllers;
using Soft.Wpf.Controllers.Cadastros.Core.Interfaces;
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

namespace Soft.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for Buttons.xaml
    /// </summary>
    public partial class Buttons : UserControl, IButtons
    {
        private IControllerRegister _action;

        public Buttons()
        {
            InitializeComponent();
        }

        public void InjectController(IControllerRegister action)
        {
            _action = action;
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            _action.New();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _action.Save();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _action.Delete();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _action.Cancel();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _action.Next();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            _action.Previous();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _action.Last();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            _action.First();
        }

        public void BlockButtons()
        {
            btnCancelar.Visibility = System.Windows.Visibility.Visible;
            btnSave.Visibility = System.Windows.Visibility.Visible;

            btnNext.Visibility = System.Windows.Visibility.Collapsed;
            btnExcluir.Visibility = System.Windows.Visibility.Collapsed;
            btnFirst.Visibility = System.Windows.Visibility.Collapsed;
            btnLast.Visibility = System.Windows.Visibility.Collapsed;
            btnNext.Visibility = System.Windows.Visibility.Collapsed;
            btnPrevious.Visibility = System.Windows.Visibility.Collapsed;
        }

        public void UnblockButtons()
        {
            btnCancelar.Visibility = System.Windows.Visibility.Collapsed;
            btnSave.Visibility = System.Windows.Visibility.Collapsed;

            btnNew.Visibility = System.Windows.Visibility.Visible;
            btnExcluir.Visibility = System.Windows.Visibility.Visible;
            btnFirst.Visibility = System.Windows.Visibility.Visible;
            btnLast.Visibility = System.Windows.Visibility.Visible;
            btnPrevious.Visibility = System.Windows.Visibility.Visible;
            btnNext.Visibility = System.Windows.Visibility.Visible;
        }
    }
}