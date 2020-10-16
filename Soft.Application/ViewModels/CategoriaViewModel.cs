using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class CategoriaViewModel : ViewModelBase
    {
        private Int64 _Cat_id;

        public Int64 Cat_id
        {
            get { return _Cat_id; }
            set
            {
                if (_Cat_id != value)
                {
                    _Cat_id = value;
                    this.OnPropertyChanged("Cat_id");
                }
            }
        }

        private string _Cat_descricao;

        public string Cat_descricao
        {
            get { return _Cat_descricao; }
            set
            {
                if (_Cat_descricao != value)
                {
                    _Cat_descricao = value;
                    this.OnPropertyChanged("Cat_descricao");
                }
            }
        }

        private bool _Cat_inativo;

        public bool Cat_inativo
        {
            get { return _Cat_inativo; }
            set
            {
                if (_Cat_inativo != value)
                {
                    _Cat_inativo = value;
                    this.OnPropertyChanged("Cat_inativo");
                }
            }
        }
    }
}