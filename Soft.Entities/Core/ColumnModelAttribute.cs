using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ColumnModelAttribute : Attribute
    {
        private readonly string _columnName;

        public string ColumName
        {
            get
            {
                return _columnName;
            }
        }

        public bool IsIdentity { get; set; }
        public bool IsPrimaryKey { get; set; }

        public ColumnModelAttribute(string columnName)
        {
            this._columnName = columnName;
        }
    }
}
