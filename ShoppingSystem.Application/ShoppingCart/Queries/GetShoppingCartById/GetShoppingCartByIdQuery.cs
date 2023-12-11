using ShoppingSystem.Application.Abstractions.Messaging;
using ShoppingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Application.ShoppingCartQueries.GetShoppingCartById
{
    public sealed record GetShoppingCartByIdQuery(int customerId) : IQuery<ShoppingCartResponse>;
}
