using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    public class Vendedor : ModelBase
    {
        public override string TableName
        {
            get
            {
                return "Vendedores";
            }
        }

        [ColumnModel("Ven_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Ven_id { get; set; }
        [ColumnModel("Ven_nome")]
        public string Ven_nome { get; set; }
        [ColumnModel("Ven_inativo")]
        public bool Ven_inativo { get; set; }
    }
}
