using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Base
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}
