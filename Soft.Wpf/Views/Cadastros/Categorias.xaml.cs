using Soft.Application.Validations;
using Soft.Application.ViewModels;
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
    /// Interaction logic for Categorias.xaml
    /// </summary>
    public partial class Categorias : Window
    {
        private CategoriasController controller = null;

        public Categorias()
        {
            InitializeComponent();

            controller = Ioc.Instance.GetInstance<CategoriasController>();            
            controller.Init(buttons);
            this.DataContext = controller;

            // events
            controller.EventNewRegister += new Delegates.RegisterNewEventHandler<Application.ViewModels.CategoriaViewModel>(NewCat);
            controller.EventValidation += new Delegates.RegisterValidationEventHandler(CheckValidation);
        }

        private bool CheckValidation()
        {
            if (!MessageValid(controller.ValidCat_descricao())) return false;
            return true;
        }

        private CategoriaViewModel NewCat()
        {
            return new CategoriaViewModel();
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
    }
}