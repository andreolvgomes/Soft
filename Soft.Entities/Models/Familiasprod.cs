using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    public class Familiasprod : ModelBase
    {
        public override string TableName
        {
            get
            {
                return "Familiasprod";
            }
        }

        [ColumnModel("Fam_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Fam_id { get; set; }
        [ColumnModel("Fam_descricao")]
        public string Fam_descricao { get; set; }
        [ColumnModel("Fam_inativo")]
        public bool Fam_inativo { get; set; }
    }
}
