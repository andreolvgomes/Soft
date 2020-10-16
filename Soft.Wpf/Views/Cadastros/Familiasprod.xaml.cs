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
    /// Interaction logic for Familiasprod.xaml
    /// </summary>
    public partial class Familiasprod : Window
    {
        private FamiliasprodController controller;

        public Familiasprod()
        {
            InitializeComponent();

            controller = Ioc.Instance.GetInstance<FamiliasprodController>();
            controller.Init(buttons);
            this.DataContext = controller;

            // events
            controller.EventNewRegister += new RegisterNewEventHandler<FamiliasprodViewModel>(NewRecord);
            controller.EventValidation += new RegisterValidationEventHandler(CheckValidation);
        }

        /// <summary>
        /// Check all validations
        /// </summary>
        /// <returns></returns>
        private bool CheckValidation()
        {
            if (!MessageValid(controller.ValidFam_descricao())) return false;
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
        /// Create a new record
        /// </summary>
        /// <returns></returns>
        private FamiliasprodViewModel NewRecord()
        {
            return new FamiliasprodViewModel();
        }
    }
}