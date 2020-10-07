using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    public class Subcategoria : ModelBase
    {
        public override string TableName
        {
            get
            {
                return "Subcategorias";
            }
        }

        [ColumnModel("Sub_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Sub_id { get; set; }
        [ColumnModel("Sub_descricao")]
        public string Sub_descricao { get; set; }
        [ColumnModel("Sub_inativo")]
        public bool Sub_inativo { get; set; }
    }
}