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
        private Int64 _Sub_id;

        public Int64 Sub_id
        {
            get { return _Sub_id; }
            set
            {
                if (_Sub_id != value)
                {
                    _Sub_id = value;
                    OnPropertyChanged("Sub_id");
                }
            }
        }

        private string _Sub_descricao;

        public string Sub_descricao
        {
            get { return _Sub_descricao; }
            set
            {
                if (_Sub_descricao != value)
                {
                    _Sub_descricao = value;
                    OnPropertyChanged("Sub_descricao");
                }
            }
        }

        private bool _Sub_inativo;

        public bool Sub_inativo
        {
            get { return _Sub_inativo; }
            set
            {
                if (_Sub_inativo != value)
                {
                    _Sub_inativo = value;
                    OnPropertyChanged("Sub_inativo");
                }
            }
        }
    }
}
