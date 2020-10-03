﻿using Soft.Domain.Interfaces.Repositories;
using Soft.Domain.Models;
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
    public class ProdutosRepository : Repository<Produtos>, IProdutosRepository
    {
    }
}