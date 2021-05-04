using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Shared.Infrastructure.Persistence.EfCore
{
    public class BillingDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Billing";

        public BillingDbContext(DbContextOptions<BillingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BillingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
