using Billing.Customers.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Value;

namespace Billing.Invoices.Domain.ValueObjects
{
    public class CustomerDetails : ValueObject
    {
        public int Age { get; private set; }
        public IdentifierValue Identifier { get; private set; }
        public string Name { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        protected CustomerDetails()
        {
        }

        public CustomerDetails(
            int age,
            IdentifierValue identifier,
            string name,
            int customerId)
        {
            Age = age;
            Identifier = identifier;
            Name = name;
            CustomerId = customerId;
        }
    }
}
