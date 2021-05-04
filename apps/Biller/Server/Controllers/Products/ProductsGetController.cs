using Billing.Products.Application.SearchAll;
using Billing.Products.Application.SearchById;
using Billing.Products.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Products
{
    [Route("api/products")]
    [ApiController]
    public class ProductsGetController : ControllerBase
    {
        private readonly ProductsSearchAllManager searchAllManager;
        private readonly ProductsSearchByIdManager searchByIdManager;

        public ProductsGetController(
            ProductsSearchAllManager searchAllManager,
            ProductsSearchByIdManager searchByIdManager)
        {
            this.searchAllManager = searchAllManager;
            this.searchByIdManager = searchByIdManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = searchAllManager.Search();
            return Ok(products);
        }

        [HttpGet("{productId:int}")]
        public IActionResult GetById(int productId)
        {
            try
            {
                var product = searchByIdManager.Search(productId);
                return Ok(product);
            }
            catch (ProductNotFound)
            {
                return NotFound();
            }
        }
    }
}
