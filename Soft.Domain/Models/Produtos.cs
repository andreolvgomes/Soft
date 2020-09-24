using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Models
{
    /// <summary>
    /// Model Produtos
    /// </summary>
    public class Produtos : BaseModel
    {
        public override string TableName
        {
            get
            {
                return "Produtos";
            }
        }

        [ColumnModel("Pro_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Pro_id { get; set; }
        [ColumnModel("Pro_descricao")]
        public string Pro_descricao { get; set; }
        [ColumnModel("Pro_pvenda")]
        public decimal Pro_pvenda { get; set; }
    }
}