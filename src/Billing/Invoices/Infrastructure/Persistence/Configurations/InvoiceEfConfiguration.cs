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
    public class InvoiceEfConfiguration : EntityTypeConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", BillingDbContext.DEFAULT_SCHEMA);

            builder.OwnsOne(i => i.CustomerDetails, cd =>
            {
                cd.OwnsOne(c => c.Identifier, id =>
                {
                    id.Property(i => i.TaxIdentifier)
                        .HasConversion<string>();
                });
                
                cd.HasOne(c => c.Customer)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.OwnsOne(i => i.TotalReceived);
            builder.OwnsOne(i => i.TotalPrice);

            builder.HasMany(i => i.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
