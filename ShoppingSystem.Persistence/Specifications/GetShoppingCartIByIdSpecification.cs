﻿using ShoppingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Specifications
{
    internal class GetShoppingCartIByIdSpecification : Specification<ShoppingCart>
    {
        public GetShoppingCartIByIdSpecification(Guid shoppingId)
         : base(p => p.Id == shoppingId) {
        }
    }
}
