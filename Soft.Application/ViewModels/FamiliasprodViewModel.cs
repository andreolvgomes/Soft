using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class FamiliasprodViewModel : ViewModelBase
    {
        public Int64 Fam_id { get; set; }
        public string Fam_descricao { get; set; }
        public bool Fam_inativo { get; set; }
    }
}
