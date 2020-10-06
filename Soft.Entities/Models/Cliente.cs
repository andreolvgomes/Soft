using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    public class Cliente : ModelBase
    {
        public override string TableName
        {
            get
            {
                return "Clientes";
            }
        }

        [ColumnModel("Cli_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Cli_id { get; set; }
        [ColumnModel("Cli_nome")]
        public string Cli_nome { get; set; }
    }
}
