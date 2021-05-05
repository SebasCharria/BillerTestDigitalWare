using Billing.Invoices.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Infrastructure.Persistence.Configurations
{
    public class InvoiceItemEfConfiguration : EntityTypeConfiguration<InvoiceItem>
    {
        public override void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("InvoiceItems", BillingDbContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(i => i.Quantity);
            builder.OwnsOne(i => i.TotalPrice);
            builder.OwnsOne(i => i.UnitPrice);
            builder.OwnsOne(i => i.UnitTax);
        }
    }
}
