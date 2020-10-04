using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Base
{
    public abstract class CommandCore
    {
        public DateTime Timestamp { get; private set; }

        protected CommandCore()
        {
            Timestamp = DateTime.Now;
        }
    }
}