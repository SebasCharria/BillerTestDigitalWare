using AutoMapper;
using Billing.Invoices.Domain;
using Billing.Invoices.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Application.SearchById
{
    public class InvoicesSearchByIdManager
    {
        private readonly IInvoiceRepository repository;
        private readonly IMapper mapper;

        public InvoicesSearchByIdManager(
            IInvoiceRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Consultar Factura"
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public InvoiceViewModel Search(int invoiceId)
        {
            var invoice = repository.GetById(invoiceId);
            if (invoice == null)
            {
                throw new InvoiceNotFound();
            }

            return mapper.Map<InvoiceViewModel>(invoice);
        }
    
    }
}
