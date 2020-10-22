using Soft.Application.Interfaces.Validations;
using Soft.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    public static class InjectorAppValidations
    {
        public static void RegisterAppValidations(this Container container)
        {
            container.Register<IVendedorValidation, VendedorValidation>();
            container.Register<ICategoriaValidation, CategoriaValidation>();
            container.Register<IFamiliasprodValidation, FamiliasprodValidation>();
            container.Register<IProdutoValidation, ProdutoValidation>();
            container.Register<ISubcategoriaValidation, SubcategoriaValidation>();
        }
    }
}
