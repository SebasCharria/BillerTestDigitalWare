using Billing.Customers.Application.SearchAll;
using Billing.Customers.Application.SearchById;
using Billing.Customers.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersGetController : ControllerBase
    {
        private readonly CustomersSearchAllManager searchAllManager;
        private readonly CustomersSearchByIdManager searchByIdManager;

        public CustomersGetController(
            CustomersSearchAllManager searchAllManager,
            CustomersSearchByIdManager searchByIdManager)
        {
            this.searchAllManager = searchAllManager;
            this.searchByIdManager = searchByIdManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = searchAllManager.Search();
            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public IActionResult GetById(int customerId)
        {
            try
            {
                var customer = searchByIdManager.Search(customerId);
                return Ok(customer);
            }
            catch (CustomerNotFound)
            {
                return NotFound();
            }
        }
    }
}
