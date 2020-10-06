using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers.Cadastros.Core.Interfaces
{
    public interface IRegisterActions
    {
        void New();
        void Save();
        void Cancel();
        void Delete();
        void Previous();
        void Next();
        void First();
        void Last();
    }
}