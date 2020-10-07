using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class SubcategoriaViewModel : ViewModelBase
    {
        public Int64 Sub_id { get; set; }
        public string Sub_descricao { get; set; }
        public bool Sub_inativo { get; set; }
    }
}
