using Billing.Customers.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Infrastructure.Persistence.Configurations
{
    public class CustomerEfConfiguration : EntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", BillingDbContext.DEFAULT_SCHEMA);
            builder.OwnsOne(c => c.Identifier, id =>
            {
                id.Property(i => i.TaxIdentifier)
                    .HasConversion<string>();
            });
        }
    }
}
