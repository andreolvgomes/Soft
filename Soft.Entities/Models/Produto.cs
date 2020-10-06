using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    /// <summary>
    /// Model Produtos
    /// </summary>
    public class Produto : ModelBase
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
        [ColumnModel("Pro_codigo")]
        public string Pro_codigo { get; set; }
        [ColumnModel("Pro_descricao")]
        public string Pro_descricao { get; set; }
        [ColumnModel("Pro_pvenda")]
        public decimal Pro_pvenda { get; set; }
        [ColumnModel("Pro_inativo")]
        public bool Pro_inativo { get; set; }
    }
}