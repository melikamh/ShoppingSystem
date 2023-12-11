using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.DomainEvents
{
    public record class ShoppingCartItemAdded(ShoppingCart shoppingCart,ShoppingCartItem item) : IDomainEvent;
    
}
