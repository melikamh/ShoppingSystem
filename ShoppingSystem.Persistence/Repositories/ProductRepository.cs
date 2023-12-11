using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Persistence.Specifications;

namespace ShoppingSystem.Persistence.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly ShoppingSystemDbContext _dbContext;
        public ProductRepository(ShoppingSystemDbContext dbContext) =>
             _dbContext = dbContext;

        public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbContext.Set<Product>()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> GetInStockByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = GetProductByIdAsync(id).Result;

            if (product != null)
            {
                return product.InStock;
            }
            return 0;
        }

        private IQueryable<Product> ApplySpecification(
       Specification<Product> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _dbContext.Set<Product>(),
                specification);
        }
    }
}
