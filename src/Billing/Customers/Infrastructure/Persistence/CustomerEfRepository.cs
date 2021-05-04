using Billing.Customers.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Infrastructure.Persistence
{
    public class CustomerEfRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerEfRepository(BillingDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
