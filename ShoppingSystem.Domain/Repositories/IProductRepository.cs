using ShoppingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id,CancellationToken cancellationToken = default);
        Task<int> GetInStockByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
