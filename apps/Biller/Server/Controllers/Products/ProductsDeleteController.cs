using Billing.Products.Application.Delete;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Products
{
    [Route("api/products/{productId:int}")]
    [ApiController]
    public class ProductsDeleteController : ControllerBase
    {
        private readonly ProductsDeleteManager deleteManager;

        public ProductsDeleteController(
            ProductsDeleteManager deleteManager)
        {
            this.deleteManager = deleteManager;
        }

        [HttpDelete]
        public IActionResult Delete(int productId)
        {
            try
            {
                deleteManager.Delete(productId);
                return NoContent();
            }
            catch (ProductNotFound)
            {
                return NotFound();
            }
        }
    
    }
}
