using Soft.Application.Interfaces.Validations;
using Soft.Domain.Interfaces.Repositories;
using Soft.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Application.Validations
{
    public class VendedorValidation : IVendedorValidation
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorValidation(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        public ValidationReturn CheckVen_inativo(long ven_id)
        {
            if (_vendedorRepository.Find(new { Ven_id = ven_id }, s => new { s.Ven_inativo }).Ven_inativo)
                return new ValidationReturn("Vendedor consta como inativo");
            return new ValidationReturn();
        }

        public ValidationReturn CheckVen_nomeIsNullOrEmpty(string ven_nome)
        {
            if (ven_nome.NullOrEmpty())
                return new ValidationReturn("Nome do vendedor não pode ser vazio");
            return new ValidationReturn();
        }

        public ValidationReturn CheckVen_nomeRegistered(long ven_id)
        {
            if (!_vendedorRepository.Exists(new { Ven_id = ven_id }))
                return new ValidationReturn("Vendedor não cadastrado");
            return new ValidationReturn();
        }

        public ValidationReturn CheckVen_nomeThereAreOtherEqual(long ven_id, string ven_nome)
        {
            Vendedor vendedor = _vendedorRepository.Find(new { Ven_nome = ven_nome }, s => new { s.Ven_id });
            if (vendedor == null)
                return new ValidationReturn();
            if (ven_id != vendedor.Ven_id)
                return new ValidationReturn("Vendedor já existe cadastrado");
            return new ValidationReturn();
        }
    }
}