using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Domain
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public IEnumerable<InvoiceItem> GetAllItems(int invoiceId);
    }
}
