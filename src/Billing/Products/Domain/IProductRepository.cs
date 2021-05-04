using Billing.Products.Domain.ValueObjects;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Domain
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
