using SimpleInjector;
using Soft.Application.Interfaces.Services;
using Soft.Application.Services;

namespace SimpleInjector
{
    public static class InjectorAppServices
    {
        public static void RegisterAppServices(this Container container)
        {
            container.Register<IProdutoAppService, ProdutoAppService>();
            container.Register<ICategoriaAppService, CategoriaAppService>();
            container.Register<ISubcategoriaAppService, SubcategoriaAppService>();
            container.Register<IFamiliasprodAppService, FamiliasprodAppService>();
            container.Register<IVendedorAppService, VendedorAppService>();
            container.Register<IClienteAppService, ClienteAppService>();
        }
    }
}