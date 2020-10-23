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
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        private ClientesController controller;

        public Clientes()
        {
            InitializeComponent();

            controller = Ioc.Instance.GetInstance<ClientesController>();
            controller.Init(buttons);
            this.DataContext = controller;

            //events
            controller.EventNewRegister += new RegisterNewEventHandler<ClienteViewModel>(NewClient);
            controller.EventValidation += new RegisterValidationEventHandler(CheckValidations);
        }

        /// <summary>
        /// It first, check all validations
        /// </summary>
        /// <returns></returns>
        private bool CheckValidations()
        {
            if (!MessageValid(controller.ValidCliente())) return false;
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

        /// <summary>
        /// Create new instance of cliente model
        /// </summary>
        /// <returns></returns>
        private ClienteViewModel NewClient()
        {
            return new ClienteViewModel();
        }
    }
}