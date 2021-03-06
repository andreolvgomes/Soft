﻿using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Inteface repository of the Produtos
    /// </summary>
    public interface IProdutoRepository : IRepository<Produto>
    {
    }
}