using ShoppingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Constants
{
    internal static class TableNames
    {
        internal const string Product = nameof(Product);

        internal const string ShoppingCart = nameof(ShoppingCart);

        internal const string ShoppingCartItem = nameof(ShoppingCartItem);
    }

}
