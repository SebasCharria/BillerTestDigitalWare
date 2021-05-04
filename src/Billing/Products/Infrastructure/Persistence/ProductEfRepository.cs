using Billing.Products.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Infrastructure.Persistence
{
    public class ProductEfRepository : EfRepository<Product>, IProductRepository
    {
        public ProductEfRepository(BillingDbContext context)
            : base(context)
        {
        }
    }
}
