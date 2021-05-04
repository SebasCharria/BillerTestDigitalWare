using Billing.Products.Application.Update;
using Billing.Products.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Products.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Products
{
    [Route("api/products/{productId:int}")]
    [ApiController]
    public class ProductsPutController : ControllerBase
    {
        private readonly ProductsUpdateManager updateManager;

        public ProductsPutController(
            ProductsUpdateManager updateManager)
        {
            this.updateManager = updateManager;
        }

        [HttpPut]
        public IActionResult Put(
            int productId, ProductRequest productRequest)
        {
            try
            {
                var product = updateManager.Update(
                    productId,
                    productRequest.Description,
                    productRequest.Name,
                    productRequest.FriendlyName,
                    productRequest.Price,
                    productRequest.Tax,
                    productRequest.TaxDescription);

                return Ok(product);
            }
            catch (ProductNotFound)
            {
                return NotFound();
            }
        }
    }
}
