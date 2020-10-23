using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class ClienteViewModel : ViewModelBase
    {
        private Int64 _Cli_id;

        public Int64 Cli_id
        {
            get { return _Cli_id; }
            set
            {
                if (_Cli_id != value)
                {
                    _Cli_id = value;
                    this.OnPropertyChanged("Cli_id");
                }
            }
        }

        private string _Cli_nome;

        public string Cli_nome
        {
            get { return _Cli_nome; }
            set
            {
                if (_Cli_nome != value)
                {
                    _Cli_nome = value;
                    this.OnPropertyChanged("Cli_nome");
                }
            }
        }

        private bool _Cli_inativo;

        public bool Cli_inativo
        {
            get { return _Cli_inativo; }
            set
            {
                if (_Cli_inativo != value)
                {
                    _Cli_inativo = value;
                    this.OnPropertyChanged("Cli_inativo");
                }
            }
        }
    }
}