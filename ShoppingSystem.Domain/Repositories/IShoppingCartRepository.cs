using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetAsync(ShoppingCartId id);
        Task<ShoppingCart> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default);
        void Add(ShoppingCart shoppingCart);
        void Delete(ShoppingCart shoppingCart);
    }
}
