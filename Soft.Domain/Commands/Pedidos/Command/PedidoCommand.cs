using Soft.Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.Pedidos.Command
{
    public class PedidoCommand : CommandCore
    {
        public Int64 Ped_id { get; set; }
        public Int64 Cli_id { get; set; }
        public decimal Ped_totgeralsdesc { get; set; }
        public decimal Ped_totgeralcdesc { get; set; }
        public decimal Ped_totgeralsdesc_prod { get; set; }
        public decimal Ped_totgeralcdesc_prod { get; set; }
        public decimal Ped_totgeralsdesc_serv { get; set; }
        public decimal Ped_totgeralcdesc_serv { get; set; }
        public decimal Ped_desc_acresc_prod { get; set; }
        public decimal Ped_desc_acres_tipo_prod { get; set; }
        public decimal Ped_desc_acresc_serv { get; set; }
        public decimal Ped_desc_acres_tipo_serv { get; set; }
    }
}