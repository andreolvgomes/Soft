using Soft.Domain.Interfaces.Repositories;
using Soft.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    public static class InjectorRepositories
    {
        public static void RegisterRepositories(this Container container)
        {
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IPedidoRepository, PedidoRepository>();
            container.Register<IPeitemRepository, PeitemRepository>();

            container.Register<IProdutoRepository, ProdutoRepository>();
            container.Register<ICategoriaRepository, CategoriaRepository>();
            container.Register<ISubcategoriaRepository, SubcategoriaRepository>();
            container.Register<IFamiliasprodRepository, FamiliasprodRepository>();
            container.Register<IVendedorRepository, VendedorRepository>();
        }
    }
}