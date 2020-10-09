using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Entities.Models
{
    public class Pedido : ModelBase
    {
        public override string TableName
        {
            get
            {
                return "Pedidos";
            }
        }

        [ColumnModel("Ped_id", IsPrimaryKey = true, IsIdentity = true)]
        public Int64 Ped_id { get; set; }
        [ColumnModel("Cli_id")]
        public Int64 Cli_id { get; set; }
        [ColumnModel("Ped_totgeralsdesc")]
        public decimal Ped_totgeralsdesc { get; set; }
        [ColumnModel("Ped_totgeralcdesc")]
        public decimal Ped_totgeralcdesc { get; set; }
        [ColumnModel("Ped_totgeralsdesc_prod")]
        public decimal Ped_totgeralsdesc_prod { get; set; }
        [ColumnModel("Ped_totgeralcdesc_prod")]
        public decimal Ped_totgeralcdesc_prod { get; set; }
        [ColumnModel("Ped_totgeralsdesc_serv")]
        public decimal Ped_totgeralsdesc_serv { get; set; }
        [ColumnModel("Ped_totgeralcdesc_serv")]
        public decimal Ped_totgeralcdesc_serv { get; set; }
        [ColumnModel("Ped_desc_acresc_prod")]
        public decimal Ped_desc_acresc_prod { get; set; }
        [ColumnModel("Ped_desc_acres_tipo_prod")]
        public decimal Ped_desc_acres_tipo_prod { get; set; }
        [ColumnModel("Ped_desc_acresc_serv")]
        public decimal Ped_desc_acresc_serv { get; set; }
        [ColumnModel("Ped_desc_acres_tipo_serv")]
        public decimal Ped_desc_acres_tipo_serv { get; set; }
        [ColumnModel("Ped_canc")]
        public bool Ped_canc { get; set; }
    }
}
