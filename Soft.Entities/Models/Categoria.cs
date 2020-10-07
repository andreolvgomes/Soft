using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    public class Categoria : ModelBase
    {
        public override string TableName
        {
            get
            {
                return "Categorias";
            }
        }

        [ColumnModel("Cat_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Cat_id { get; set; }
        [ColumnModel("Cat_descricao")]
        public string Cat_descricao { get; set; }
        [ColumnModel("Cat_inativo")]
        public bool Cat_inativo { get; set; }
    }
}
