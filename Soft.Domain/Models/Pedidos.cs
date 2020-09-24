using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Models
{
    public class Pedidos : BaseModel
    {
        public override string TableName
        {
            get
            {
                return "Orcamentos";
            }
        }

        [ColumnModel("Ped_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Ped_id { get; set; }
        [ColumnModel("Cli_id")]
        public Int64 Cli_id { get; set; }
        [ColumnModel("Ped_totgeral")]
        public decimal Ped_totgeral { get; set; }
    }
}
