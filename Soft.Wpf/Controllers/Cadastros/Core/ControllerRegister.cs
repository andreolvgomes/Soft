using Soft.Application.Interfaces.Services;
using Soft.Application.ViewModels;
using Soft.Wpf.Controllers.Cadastros.Core.Enums;
using Soft.Wpf.Controllers.Cadastros.Core.Interfaces;
using Soft.Wpf.Delegates;
using Soft.Wpf.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers.Cadastros.Core
{
    public class ControllerRegister<T> : INotifyPropertyChanged, IControllerRegister
        where T : ViewModelBase
    {
        /// <summary>
        /// Clone
        /// </summary>
        private T _entity_clone;
        private T _entity;
        /// <summary>
        /// Entidade ViewModel
        /// </summary>
        public T Entity
        {
            get { return _entity; }
            set
            {
                if (_entity != value)
                {
                    if (_entity != null)
                        _entity.PropertyChanged -= OnEntityPropertyChanged;

                    _entity = value;
                    OnPropertyChanged("Entity");

                    if (OperationCurrent != Operation.New)
                        OnEventTreatToView(_entity);

                    if (_entity != null)
                    {
                        _entity_clone = (T)_entity.Clone();
                        _entity.PropertyChanged += OnEntityPropertyChanged;
                    }
                }
            }
        }

        private void OnEntityPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (OperationCurrent == Operation.Navigate)
            {
                OperationCurrent = Operation.Edit;
                _buttons.BlockButtons();
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

        #region Events

        public event RegisterTreatEventHandler<T> EventTreatToDatabase;
        public event RegisterTreatEventHandler<T> EventTreatToView;
        public event RegisterNewEventHandler<T> EventNewRegister;
        public event RegisterValidationEventHandler EventValidation;

        private void OnEventTreatToDatabase()
        {
            var handler = EventTreatToDatabase;
            if (handler != null)
                handler(this.Entity);
        }

        private void OnEventTreatToView(T entity)
        {
            var handler = EventTreatToView;
            if (handler != null)
                handler(entity);
        }

        private T OnEventNewRegister()
        {
            var handler = EventNewRegister;
            if (handler != null)
                return handler();

            throw new Exception("Faça a implementação desse event");
        }

        private bool OnEventValidation()
        {
            var handler = EventValidation;
            if (handler != null)
                return handler();
            return true;
        }

        #endregion

        private int index = 0;
        private int n_records = 0;
        private Operation OperationCurrent = Operation.Navigate;

        /// <summary>
        /// Service from layer Services
        /// </summary>
        private readonly IRegisterAppService<T> _appService = null;
        private IButtons _buttons = null;

        /// <summary>
        /// ControllerRegister
        /// </summary>
        /// <param name="appService"></param>
        public ControllerRegister(IRegisterAppService<T> appService)
        {
            _appService = appService;
            Entity = (T)Activator.CreateInstance(typeof(T));
        }        

        /// <summary>
        /// Start
        /// </summary>
        public void Init()
        {
            n_records = _appService.Count();
            this.First();
        }

        public void DefinesButton(IButtons buttons)
        {
            _buttons = buttons;
            _buttons.UnblockButtons();
        }

        /// <summary>
        /// Create new viewmodel
        /// </summary>
        public bool New()
        {
            OperationCurrent = Operation.New;
            _buttons.BlockButtons();

            Entity = OnEventNewRegister();
            return true;
        }

        /// <summary>
        /// Save viewmodel in the database
        /// </summary>
        public bool Save()
        {
            if (OnEventValidation())
            {
                OnEventTreatToDatabase();
                if (OperationCurrent == Operation.New)
                {
                    long id = _appService.Insert(_entity);
                    n_records = _appService.Count();

                    // go to last record
                    Last();
                    OnEventTreatToView(_entity);
                }
                else
                {
                    _appService.Update(_entity);
                }
                OperationCurrent = Operation.Navigate;
                _buttons.UnblockButtons();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cancel operation of New or Edit
        /// </summary>
        public bool Cancel()
        {
            OperationCurrent = Operation.Navigate;

            Entity = Offset(index);            
            _buttons.UnblockButtons();
            return true;
        }

        /// <summary>
        /// Delete viewmodel in the database
        /// </summary>
        public bool Delete()
        {
            _appService.Delete(Entity);
            n_records = _appService.Count();
            First();
            return true;
        }

        /// <summary>
        /// Navigate to the previous record
        /// </summary>
        public void Previous()
        {
            if (index > 0)
                index -= 1;
            SetEntity(Offset(index));
        }

        /// <summary>
        /// Navigate to the next record
        /// </summary>
        public void Next()
        {
            if (index < n_records - 1)
                index++;
            SetEntity(Offset(index));
        }

        /// <summary>
        /// Navigate to the first record
        /// </summary>
        public void First()
        {
            if (index != 0) index = 0;
            SetEntity(Offset(index));
        }

        /// <summary>
        /// Navigate to the last record
        /// </summary>
        public void Last()
        {
            if (n_records > 0 && index != n_records - 1)
                index = n_records - 1;
            SetEntity(Offset(index));
        }

        /// <summary>
        /// Set viewmodel
        /// </summary>
        /// <param name="entity"></param>
        private void SetEntity(T entity)
        {
            if (entity != null)
                Entity = entity;
        }

        /// <summary>
        /// Navigate record from database by offset
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private T Offset(int index)
        {
            return _appService.FindOffset(index);
        }
    }
}