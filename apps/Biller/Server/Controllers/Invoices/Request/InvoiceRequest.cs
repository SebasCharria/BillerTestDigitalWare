using Billing.Invoices.Application;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Infrastructure.Mvc.JsonConverts;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Invoices.Request
{
    public class InvoiceRequest
    {
        public DateTime ExpirationDate { get; set; }
        public MonetaryValue TotalReceived { get; set; }
        public int CustomerId { get; set; }
        public List<ProductInputModel> Products { get; set; }
    }
}
