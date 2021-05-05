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
    public class StockQuantityHistoryEfConfiguration : EntityTypeConfiguration<StockQuantityHistory>
    {
        public override void Configure(EntityTypeBuilder<StockQuantityHistory> builder)
        {
            builder.ToTable("ProductStockHistories", BillingDbContext.DEFAULT_SCHEMA);

            builder.OwnsOne(h => h.QuantityAdjustment);
            builder.OwnsOne(h => h.StockQuantity);
        }
    }
}
