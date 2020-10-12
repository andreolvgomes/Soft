using SimpleInjector;
using Soft.Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Boostrapper
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;

        public CommandDispatcher(Container container)
        {
            _container = container;
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            //var handler = _container.GetAllInstances<ICommandHandler<T>>().Single();
            var handler = _container.GetInstance<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}
