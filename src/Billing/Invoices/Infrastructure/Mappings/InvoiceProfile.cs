using AutoMapper;
using Billing.Invoices.Application;
using Billing.Invoices.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Infrastructure.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceViewModel>();
            CreateMap<InvoiceItem, InvoiceItemViewModel>();
        }
    }
}
