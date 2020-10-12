using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class ProdutoViewModel : ViewModelBase
    {
        public Int64 Cat_id { get; set; }
        public Int64 Fam_id { get; set; }
        public Int64 Sub_id { get; set; }

        private Int64 _Pro_id;

        public Int64 Pro_id
        {
            get { return _Pro_id; }
            set
            {
                if (_Pro_id != value)
                {
                    _Pro_id = value;
                    OnPropertyChanged("Pro_id");
                }
            }
        }

        private string _Pro_codigo;

        public string Pro_codigo
        {
            get { return _Pro_codigo; }
            set
            {
                if (_Pro_codigo != value)
                {
                    _Pro_codigo = value;
                    OnPropertyChanged("Pro_codigo");
                }
            }
        }

        private string _Pro_descricao;

        public string Pro_descricao
        {
            get { return _Pro_descricao; }
            set
            {
                if (_Pro_descricao != value)
                {
                    _Pro_descricao = value;
                    OnPropertyChanged("Pro_descricao");
                }
            }
        }

        private string _Cat_descricaoView;

        public string Cat_descricaoView
        {
            get { return _Cat_descricaoView; }
            set
            {
                if (_Cat_descricaoView != value)
                {
                    _Cat_descricaoView = value;
                    OnPropertyChanged("Cat_descricaoView");
                }
            }
        }

        private string _Fam_descricaoView;

        public string Fam_descricaoView
        {
            get { return _Fam_descricaoView; }
            set
            {
                if (_Fam_descricaoView != value)
                {
                    _Fam_descricaoView = value;
                    OnPropertyChanged("Fam_descricaoView");
                }
            }
        }

        private string _Sub_descricaoView;

        public string Sub_descricaoView
        {
            get { return _Sub_descricaoView; }
            set
            {
                if (_Sub_descricaoView != value)
                {
                    _Sub_descricaoView = value;
                    OnPropertyChanged("Sub_descricaoView");
                }
            }
        }
    }
}
