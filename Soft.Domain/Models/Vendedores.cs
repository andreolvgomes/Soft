using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Models
{
    public class Vendedores : BaseModel
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
    }
}
