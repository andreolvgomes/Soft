﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
