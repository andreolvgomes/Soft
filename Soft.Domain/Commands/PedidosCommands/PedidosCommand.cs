using Soft.Domain.Commands.Base;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Commands.PedidosCommands
{
    public class PedidosCommand : Command
    {
        public Pedidos Pedidos { get; private set; }

        public PedidosCommand(Pedidos pedidos)
        {
            this.Pedidos = pedidos;
        }
    }
}