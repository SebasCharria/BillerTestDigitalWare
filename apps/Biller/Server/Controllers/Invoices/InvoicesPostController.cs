using Billing.Customers.Domain.Exceptions;
using Billing.Invoices.Application;
using Billing.Invoices.Application.Create;
using Billing.Products.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Invoices.Request;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Invoices
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoicesPostController : ControllerBase
    {
        private readonly InvoicesCreateManager createManager;

        public InvoicesPostController(
            InvoicesCreateManager createManager)
        {
            this.createManager = createManager;
        }

        [HttpPost]
        public IActionResult Post([FromBody] InvoiceRequest request)
        {
            try
            {
                var invoice = createManager.Create(
                    date: DateTime.Now,
                    expirationDate: request.ExpirationDate,
                    totalReceived: request.TotalReceived,
                    customerId: request.CustomerId,
                    productInputs: request.Products);

                return CreatedAtAction(
                    nameof(InvoicesGetController.GetById),
                    nameof(InvoicesGetController).Replace("Controller", ""),
                    new { invoiceId = invoice.Id },
                    invoice);
            }
            catch (ProductNotFound)
            {
                return NotFound();
            }
            catch (CustomerNotFound)
            {
                return NotFound();
            }
        }
    }
}
