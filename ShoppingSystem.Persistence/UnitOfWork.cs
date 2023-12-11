using ShoppingSystem.Domain.Repositories;
using ShoppingSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingSystemDbContext _dbContext;

        public UnitOfWork(ShoppingSystemDbContext dbContext) => _dbContext = dbContext;

        public int SaveChanges(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChanges();
    }
}
