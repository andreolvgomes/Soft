using Soft.Application.Interfaces.Services;
using Soft.Wpf.Controllers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Wpf.Controllers
{
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoAppService _pedidoAppService;

        public PedidosController(IPedidoAppService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }
    }
}