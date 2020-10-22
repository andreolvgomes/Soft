using Soft.Application.Validations;
using Soft.Application.ViewModels;
using Soft.Infra.IoC;
using Soft.Wpf.Controllers.Cadastros;
using Soft.Wpf.Delegates;
using System;
using System.CodeDom;
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
    /// Interaction logic for Vendedores.xaml
    /// </summary>
    public partial class Vendedores : Window
    {
        private VendedoresController controller = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public Vendedores()
        {
            InitializeComponent();

            controller = Ioc.Instance.GetInstance<VendedoresController>();
            this.DataContext = controller;

            controller.Init(buttons);

            // events
            controller.EventNewRegister += new RegisterNewEventHandler<VendedorViewModel>(NewVendedor);
            controller.EventValidation += new RegisterValidationEventHandler(CheckValidations);
        }

        /// <summary>
        /// Check all validations
        /// </summary>
        /// <returns></returns>
        private bool CheckValidations()
        {
            if (!MessageValid(controller.ValidVen_nome())) return false;
            return true;
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

        private VendedorViewModel NewVendedor()
        {
            return new VendedorViewModel();
        }
    }
}
