using Billing.Products.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Products.Infrastructure.Persistence
{
    public class ProductEfRepository : EfRepository<Product>, IProductRepository
    {
        public ProductEfRepository(BillingDbContext context)
            : base(context)
        {
        }

        public new Product GetById(object id)
        {
            return Entities
                .Include(p => p.StockQuantityHistories)
                .FirstOrDefault(p => p.Id == (int)id);
        }

    }
}
