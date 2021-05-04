using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application
{
    public class ProductAjustInputModel
    {
        public int ProductId { get; set; }
        public QuantityValue Quantity { get; set; }
    }
}
