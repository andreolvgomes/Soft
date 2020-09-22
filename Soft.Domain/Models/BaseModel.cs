using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Models
{
    public abstract class BaseModel : INotifyPropertyChanged, ICloneable
    {
        public abstract string TableName { get; }

        [ColumnModel("CreateUser")]
        public string CreateUser { get; set; }
        [ColumnModel("UpdateUser")]
        public string UpdateUser { get; set; }

        [ColumnModel("CreateAt")]
        public DateTime CreateAt { get; set; }
        [ColumnModel("UpdateAt")]
        public DateTime UpdateAt { get; set; }

        public BaseModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Executa PropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.Clone();
        }
    }
}
