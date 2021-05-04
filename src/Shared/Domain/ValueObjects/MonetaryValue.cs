using System;
using System.Collections.Generic;
using System.Text;
using Value;

namespace Shared.Domain.ValueObjects
{
    public class MonetaryValue : ValueObject
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }

        protected MonetaryValue()
        {
        }

        public MonetaryValue(
            decimal value,
            string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
