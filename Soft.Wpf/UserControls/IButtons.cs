using Soft.Wpf.Controllers.Cadastros.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.UserControls
{
    public interface IButtons
    {
        void InjectController(IControllerRegister controller);
        void BlockButtons();
        void UnblockButtons();
    }
}