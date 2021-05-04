using Billing.Products.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Infrastructure.Persistence.Configurations
{
    public class ProductEfConfiguration : EntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", BillingDbContext.DEFAULT_SCHEMA);
            builder.OwnsOne(p => p.Price);
            builder.OwnsOne(p => p.StockQuantity);
            builder.OwnsOne(p => p.Tax);

            builder.HasMany(p => p.StockQuantityHistories)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
