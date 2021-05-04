using Billing.Invoices.Domain;
using Billing.Invoices.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Application.Delete
{
    public class InvoicesDeleteManager
    {
        private readonly IInvoiceRepository repository;

        public InvoicesDeleteManager(
            IInvoiceRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Caso de uso "Eliminar facturas".
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <exception cref="InvoiceNotFound"></exception>
        public void Delete(int invoiceId)
        {
            var invoice = repository.GetById(invoiceId);

            if (invoice == null)
            {
                throw new InvoiceNotFound();
            }

            repository.Delete(invoice);

        }
    }
}
