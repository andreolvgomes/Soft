﻿using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Infra.Data.Repositories
{
    /// <summary>
    /// Repository of Produtos
    /// </summary>
    public class ProdutoRepository : Repository<Produto>, IProdutosRepository
    {
    }
}