using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Persistence.Constants;

namespace ShoppingSystem.Persistence
{
    public sealed class ShoppingSystemDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public ShoppingSystemDbContext()
        {

        }

        public ShoppingSystemDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBSettings.ConnectionString);
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseInMemoryDatabase(databaseName: "ShoppingSystemDb");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
           modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

    }
}

