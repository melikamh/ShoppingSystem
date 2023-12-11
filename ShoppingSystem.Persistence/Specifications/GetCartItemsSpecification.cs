using ShoppingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Specifications
{
    internal class GetCartItemsSpecification : Specification<ShoppingCartItem>
    {
        public GetCartItemsSpecification(Guid shoppingId)
         : base(p => p.ShoppingCartId == shoppingId)
        {
            AddInclude(item => item.Product);
        }
    }
}
