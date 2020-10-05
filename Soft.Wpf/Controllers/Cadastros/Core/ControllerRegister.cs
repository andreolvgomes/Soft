using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Wpf.Controllers.Cadastros.Core.Enums;
using Soft.Wpf.Controllers.Cadastros.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers.Cadastros.Core
{
    public class ControllerRegister<T> : INotifyPropertyChanged, IRegisterActions
        where T : ViewModelBase
    {
        private T _entidade;

        public T Entidade
        {
            get { return _entidade; }
            set
            {
                if (_entidade != value)
                {
                    _entidade = value;
                    this.OnPropertyChanged("Entidade");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int index = 0;
        private int n_records = 0;
        private Operation Oper = Operation.Navigate;

        private readonly IRegisterAppService<T> _appService = null;

        public ControllerRegister(IRegisterAppService<T> appService)
        {
            _appService = appService;
            Entidade = (T)Activator.CreateInstance(typeof(T));
        }

        public virtual void Init()
        {
            n_records = _appService.Count();
            this.First();
        }

        public void Novo()
        {            
            Entidade = (T)Activator.CreateInstance(typeof(T));
            Oper = Operation.New;
        }

        public void Save()
        {
            _appService.Update(_entidade);
            Oper = Operation.Navigate;
        }

        public void Cancel()
        {
            Entidade = Offset(index);
            Oper = Operation.Navigate;
        }

        public void Delete()
        {
            _appService.Delete(Entidade);
            n_records = _appService.Count();
            First();
        }

        public void Previous()
        {
            if (index > 0)
                index -= 1;
            Entidade = Offset(index);
        }

        public void Next()
        {
            if (index < n_records - 1) 
                index++;
            Entidade = Offset(index);
        }

        public void First()
        {
            if (index != 0) index = 0;
            Entidade = Offset(index);
        }

        public void Last()
        {
            if (index != n_records - 1) 
                index = n_records - 1;
            Entidade = Offset(index);
        }

        private T Offset(int index)
        {
            return _appService.FindOffset(index);
        }
    }
}