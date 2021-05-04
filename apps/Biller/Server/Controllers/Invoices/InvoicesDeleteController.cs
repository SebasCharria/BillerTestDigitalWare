using Billing.Invoices.Application.Delete;
using Billing.Invoices.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Invoices
{
    [Route("api/invoices/{invoiceId:int}")]
    [ApiController]
    public class InvoicesDeleteController : ControllerBase
    {
        private readonly InvoicesDeleteManager deleteManager;

        public InvoicesDeleteController(
            InvoicesDeleteManager deleteManager)
        {
            this.deleteManager = deleteManager;
        }

        [HttpDelete]
        public IActionResult Delete(int invoiceId)
        {
            try
            {
                deleteManager.Delete(invoiceId);
                return NoContent();
            }
            catch (InvoiceNotFound)
            {
                return NotFound();
                throw;
            }
        }
    
    }
}
