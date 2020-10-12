using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers.Cadastros.Core.Interfaces
{
    public interface IRegisterActions
    {
        bool New();
        bool Save();
        bool Cancel();
        bool Delete();
        void Previous();
        void Next();
        void First();
        void Last();
    }
}