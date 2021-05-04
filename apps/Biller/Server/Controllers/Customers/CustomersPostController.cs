using Billing.Customers.Application.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Customers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersPostController : ControllerBase
    {
        private readonly CustomersCreateManager createManager;

        public CustomersPostController(
            CustomersCreateManager createManager)
        {
            this.createManager = createManager;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerRequest customerRequest)
        {
            var customer = createManager.Create(
                age: customerRequest.Age,
                email: customerRequest.Email,
                identifier: customerRequest.Identifier,
                name: customerRequest.Name);

            return CreatedAtAction(nameof(CustomersGetController.GetById),
                nameof(CustomersGetController).Replace("Controller", ""),
                new { customerId = customer.Id },
                customer);
        }
    }
}
