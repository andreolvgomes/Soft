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
        private Int64 _Fam_id;

        public Int64 Fam_id
        {
            get { return _Fam_id; }
            set
            {
                if (_Fam_id != value)
                {
                    _Fam_id = value;
                    this.OnPropertyChanged("Fam_id");
                }
            }
        }

        private string _Fam_descricao;

        public string Fam_descricao
        {
            get { return _Fam_descricao; }
            set
            {
                if (_Fam_descricao != value)
                {
                    _Fam_descricao = value;
                    this.OnPropertyChanged("Fam_descricao");
                }
            }
        }
        private bool _Fam_inativo;

        public bool Fam_inativo
        {
            get { return _Fam_inativo; }
            set
            {
                if (_Fam_inativo != value)
                {
                    _Fam_inativo = value;
                    this.OnPropertyChanged("Fam_inativo");
                }
            }
        }
    }
}