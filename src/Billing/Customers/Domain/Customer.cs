using Shared.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Domain
{
    public class Customer: Entity, IAggregateRoot
    {
        public int Age { get; private set; }
        public string Email { get; private set; }
        public IdentifierValue Identifier { get; private set;  }
        public string Name { get; private set; }

        protected Customer()
        {
        }

        public Customer(
            int age,
            string email,
            IdentifierValue identifier,
            string name)
        {
            Age = age;
            Email = email;
            Identifier = identifier;
            Name = name;
        }

        public void ChangeEmail(string email)
        {
            if(Email != email) Email = email;
        }
        public void ChangeAge(int age)
        {
            if (Age != age) Age = age;
        }
    }
}
