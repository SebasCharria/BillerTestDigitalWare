using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Domain
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
