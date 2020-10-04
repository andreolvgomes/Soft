﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class ProdutoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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
    }
}