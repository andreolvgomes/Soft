using Soft.Domain.Commands.Core;
using Soft.Domain.Commands.Core.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    public static class InjectorCommands
    {
        public static void RegisterCommands(this Container container)
        {
            container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });
            container.Register<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
