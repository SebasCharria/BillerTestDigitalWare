using Billing.Invoices.Domain;
using Billing.Shared.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Invoices.Infrastructure.Persistence
{
    public class InvoiceEfRepository : EfRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceEfRepository(BillingDbContext context)
            : base(context)
        {
        }

        public IEnumerable<InvoiceItem> GetAllItems(int invoiceId)
        {
            return Entities
                .AsNoTracking()
                .Include(i => i.Items)
                    .ThenInclude(i => i.Product)
                .Where(i => i.Id == invoiceId)
                .SelectMany(i => i.Items)
                .ToList();
        }
    }
}
