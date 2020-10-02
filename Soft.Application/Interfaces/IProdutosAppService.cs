using Soft.Application.Interfaces;
using Soft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Interfaces
{
    public interface IProdutosAppService //: IBaseAppService<Produtos>
    {
        void Create(Produtos produtos);
        void Delete(Int64 pro_id);
        Produtos FindById(Int64 pro_id);
    }
}
