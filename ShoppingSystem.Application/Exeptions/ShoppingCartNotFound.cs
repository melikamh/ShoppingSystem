using ShoppingSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Application.Exceptions
{
    public class ShoppingCartNotFound : DomainException
    {
        public Guid Id { get; }

        public ShoppingCartNotFound(Guid id) : base($"Shopping cart with ID '{id}' was not found.")
            => Id = id;
    }
}
