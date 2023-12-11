using ShoppingSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Application.Exceptions
{
    public class ProductNotFound : DomainException
    {
        public int Id { get; }

        public ProductNotFound(int id) : base($"Product with ID '{id}' was not found.")
            => Id = id;
    }
}
