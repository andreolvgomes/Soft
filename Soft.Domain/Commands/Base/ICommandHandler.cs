using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Base
{
    public abstract class ICommandHandler<TCommand>
    {
        public abstract void Handler(TCommand command);

        protected void SetChangesAt<TModel>(TModel model) where TModel : BaseModel
        {
        }
    }
}