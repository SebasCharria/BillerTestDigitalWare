using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Application
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public IdentifierValue Identifier { get; private set; }
        public string Name { get; private set; }
    }
}
