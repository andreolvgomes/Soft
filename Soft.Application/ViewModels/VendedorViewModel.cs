using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class VendedorViewModel : ViewModelBase
    {
        private Int64 _Ven_id;

        public Int64 Ven_id
        {
            get { return _Ven_id; }
            set
            {
                if (_Ven_id != value)
                {
                    _Ven_id = value;
                    this.OnPropertyChanged("Ven_id");
                }
            }
        }

        private string _Ven_nome;

        public string Ven_nome
        {
            get { return _Ven_nome; }
            set
            {
                if (_Ven_nome != value)
                {
                    _Ven_nome = value;
                    this.OnPropertyChanged("Ven_nome");
                }
            }
        }

        private bool _ven_inativo;

        public bool Ven_inativo
        {
            get { return _ven_inativo; }
            set
            {
                if (_ven_inativo != value)
                {
                    _ven_inativo = value;
                    this.OnPropertyChanged("Ven_inativo");
                }
            }
        }
    }
}
