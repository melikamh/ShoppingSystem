using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Persistence.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Repositories
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly ShoppingSystemDbContext _dbContext;

        public ShoppingCartItemRepository(ShoppingSystemDbContext dbContext) =>
            _dbContext = dbContext;
        public void AddToCart(ShoppingCartItem item) =>
           _dbContext.Set<ShoppingCartItem>().Add(item);

        public void RemoveFromCart(int itemId) =>
            _dbContext.Set<ShoppingCartItem>().Remove(GetCartItemById(itemId));

        public async Task<List<ShoppingCartItem>> GetCartItems(Guid shoppingCartId, CancellationToken cancellationToken = default) =>
            await ApplySpecification(new GetCartItemsSpecification(shoppingCartId)).ToListAsync(cancellationToken);

        
        private IQueryable<ShoppingCartItem> ApplySpecification(
             Specification<ShoppingCartItem> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _dbContext.Set<ShoppingCartItem>(),
                specification);
        }

        private ShoppingCartItem GetCartItemById(int itemId) =>
            _dbContext.Set<ShoppingCartItem>().Find(itemId);
    }
}
