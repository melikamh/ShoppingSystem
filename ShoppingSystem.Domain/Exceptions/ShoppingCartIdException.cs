using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.Exceptions
{
    internal class ShoppingCartIdException :DomainException
    {
        public ShoppingCartIdException() : base("Shopping Card ID cannot be empty")
        {
        }
    }
}
