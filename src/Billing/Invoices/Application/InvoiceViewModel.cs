using Billing.Invoices.Domain.ValueObjects;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Application
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpirationDate { get; set; }
        public MonetaryValue TotalReceived { get; set; }
        public int TotalItems { get; set; }
        public MonetaryValue TotalPrice { get; set; }
        public IEnumerable<InvoiceItem> Items { get; set; }
    }
}
