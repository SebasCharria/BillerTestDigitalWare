using Billing.Customers.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using RandomNameGeneratorLibrary;
using Shared.Domain.ValueObjects;
using Shared.Domain.Enums;

namespace BillingTest.Customers.Domain
{
    public class CustomerMother
    {
        public static Customer Random()
        {
            var random = new Random();
            var randomName = new PersonNameGenerator();
            return new Customer(
                random.Next(1, 80),
                randomName.GenerateRandomFirstAndLastName(),
                new IdentifierValue(TaxIdentifier.Cedula, "123456789"),
                randomName.GenerateRandomFirstAndLastName());
        }
    }
}
