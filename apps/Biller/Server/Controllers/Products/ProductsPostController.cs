using Billing.Products.Application.Create;
using Billing.Products.Application.SearchAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Products.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Products
{
    [Route("api/products")]
    [ApiController]
    public class ProductsPostController : ControllerBase
    {
        private readonly ProductsCreateManager createManager;

        public ProductsPostController(
            ProductsCreateManager createManager)
        {
            this.createManager = createManager;
        }

        [HttpPost]
        public IActionResult Post(ProductRequest productRequest)
        {
            var product = createManager.Create(
                productRequest.Description,
                productRequest.Name,
                productRequest.FriendlyName,
                productRequest.Price,
                productRequest.Tax,
                productRequest.InitialStock,
                productRequest.TaxDescription);

            return CreatedAtAction(
                nameof(ProductsGetController.GetById),
                nameof(ProductsGetController).Replace("Controller", ""),
                new { productId = product.Id },
                product);
        }
    }
}
