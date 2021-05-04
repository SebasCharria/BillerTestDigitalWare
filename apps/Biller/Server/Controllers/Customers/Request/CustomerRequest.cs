using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Customers.Request
{
    public class CustomerRequest
    {
        public int Age { get; set; }
        public string Email { get; set; }
        public IdentifierValue Identifier { get; set; }
        public string Name { get; set; }
    }
}
