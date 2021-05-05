using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Application
{
    public class InvoiceItemViewModel
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public QuantityValue Quantity { get; set; }
        public string TaxDescription { get; set; }
        public MonetaryValue TotalPrice { get; set; }
        public MonetaryValue UnitPrice { get; set; }
        public MonetaryValue UnitTax { get; set; }
    }
}
