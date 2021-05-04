using Billing.Invoices.Application.SearchAll;
using Billing.Invoices.Application.SearchById;
using Billing.Invoices.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Invoices
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoicesGetController : ControllerBase
    {
        private readonly InvoicesSearchAllManager searchAllManager;
        private readonly InvoicesSearchByIdManager searchByIdManager;

        public InvoicesGetController(
            InvoicesSearchAllManager searchAllManager,
            InvoicesSearchByIdManager searchByIdManager)
        {
            this.searchAllManager = searchAllManager;
            this.searchByIdManager = searchByIdManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var invoices = searchAllManager.Search();
                return Ok(invoices);
            }
            catch (InvoiceNotFound)
            {
                return NotFound();
            }
        }

        [HttpGet("{invoiceId:int}")]
        public IActionResult GetById(int invoiceId)
        {
            try
            {
                var invoice = searchByIdManager.Search(invoiceId);
                return Ok(invoice);
            }
            catch (InvoiceNotFound)
            {
                return NotFound();
            }
        }
    }
}
