using SimpleInjector;
using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
using Soft.Infra.Data.Repositories;
using Soft.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Domain
{
    public class ClientesRepositoryTests
    {
        private readonly Container _container = null;

        public ClientesRepositoryTests()
        {
            //try
            //{
            //    _container = new SimpleInjector.Container();
            //    Bindings.Register(_container);
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        [Fact]
        public void InsertTest()
        {
            try
            {
                IClientesRepository clientesRepository = new ClientesRepository();
                var result = clientesRepository.Insert(new Clientes()
                {
                    Cli_nome = "Programador 123"
                });
                Assert.True(result > 0);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }
    }
}