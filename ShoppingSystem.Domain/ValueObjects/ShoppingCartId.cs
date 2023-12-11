using ShoppingSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.ValueObjects
{
    public class ShoppingCartId
    {
        public Guid Value { get; }

        public ShoppingCartId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ShoppingCartIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(ShoppingCartId id)
          => id.Value;

        public static implicit operator ShoppingCartId(Guid id)
            => new(id);

    }
}
