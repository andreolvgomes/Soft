﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Core.Dispatcher
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
    }
}
