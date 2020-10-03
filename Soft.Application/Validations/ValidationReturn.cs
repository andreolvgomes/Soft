using Soft.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Validations
{
    public class ValidationReturn
    {
        public bool Valid
        {
            get
            {
                return Message.NullOrEmpty();
            }
        }

        public string Message { get; set; }

        public ValidationReturn()
        {
        }
        public ValidationReturn(string message)
        {
            this.Message = message;
        }

        public bool IsValid()
        {
            if (Message.NullOrEmpty())
                return true;
            return false;
        }
    }
}