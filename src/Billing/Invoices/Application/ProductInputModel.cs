using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Application
{
    public class ProductInputModel
    {
        public int ProductId { get; set; }
        public QuantityValue Quantity { get; set; }
    }
}
