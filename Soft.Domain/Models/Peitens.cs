using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Models
{
    public class Peitens : BaseModel
    {
        public override string TableName
        {
            get
            {
                return "Oritens";
            }
        }

        [ColumnModel("Pei_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Pei_id { get; set; }
        [ColumnModel("Ped_id")]
        public Int64 Ped_id { get; set; }
        [ColumnModel("Pro_id")]
        public Int64 Pro_id { get; set; }
        [ColumnModel("Ven_id")]
        public Int64 Ven_id { get; set; }
        [ColumnModel("Pei_vlunitario")]
        public decimal Pei_vlunitario { get; set; }
        [ColumnModel("Pei_quantidade")]
        public decimal Pei_quantidade { get; set; }
    }
}