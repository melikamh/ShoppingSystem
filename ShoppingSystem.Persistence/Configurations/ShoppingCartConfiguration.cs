using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Configurations
{
   

    internal sealed class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable(TableNames.ShoppingCart);

            builder.HasKey(x => x.Id);
            
            builder
                .HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(x => x.ShoppingCartId);

        }
    }
}
