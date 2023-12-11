using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Configurations
{

    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNames.Product);

            builder.HasKey(x => x.Id);
            builder.HasData(
                new Product { Id = 1, Name = "product 1", Price = 1000, InStock = 1000, },
            new Product { Id = 2, Name = "product 2", Price = 2000, InStock = 2, },
            new Product { Id = 3, Name = "product 3", Price = 3000, InStock = 1000, },
            new Product { Id = 4, Name = "product 4", Price = 4000, InStock = 1000, },
            new Product { Id = 5, Name = "product 5", Price = 5000, InStock = 1000, });

        }
    }
}
