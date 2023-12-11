using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.ValueObjects;
using ShoppingSystem.Persistence.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Repositories
{
    public sealed class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingSystemDbContext _dbContext;

        public ShoppingCartRepository(ShoppingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ShoppingCart shoppingCart) => _dbContext.Set<ShoppingCart>().Add(shoppingCart);

        public void Delete(ShoppingCart shoppingCart) => _dbContext.Set<ShoppingCart>().Remove(shoppingCart);


        public void Get(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetAsync(ShoppingCartId id) =>
             ApplySpecification(new GetShoppingCartIByIdSpecification(id)).FirstOrDefault();

        public async Task<ShoppingCart> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default) =>
           await _dbContext.Set<ShoppingCart>()
               .Where(p => p.CustomerId == customerId)
               .OrderByDescending(p=>p.DateTime)
               .FirstOrDefaultAsync(cancellationToken);

        private IQueryable<ShoppingCart> ApplySpecification(
            Specification<ShoppingCart> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _dbContext.Set<ShoppingCart>(),
                specification);
        }


    }
}