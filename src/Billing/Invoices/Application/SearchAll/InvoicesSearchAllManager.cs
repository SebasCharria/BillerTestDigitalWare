using AutoMapper;
using Billing.Invoices.Domain;
using Billing.Invoices.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Application.SearchAll
{
    public class InvoicesSearchAllManager
    {
        private readonly IInvoiceRepository repository;
        private readonly IMapper mapper;

        public InvoicesSearchAllManager(
            IInvoiceRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Consultar facturas"
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InvoiceViewModel> Search()
        {
            var invoices = repository.Search();
            if (invoices == null)
            {
                throw new InvoiceNotFound();
            }

            return mapper.Map<IEnumerable<InvoiceViewModel>>(invoices);
        }
    }
}
