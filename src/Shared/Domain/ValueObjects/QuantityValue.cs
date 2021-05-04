using System;
using System.Collections.Generic;
using System.Text;
using Value;

namespace Shared.Domain.ValueObjects
{
    public class QuantityValue: ValueObject
    {
        public decimal Value { get; private set; }
        public string UnitMeasurement { get; private set; }

        protected QuantityValue()
        {
        }

        public QuantityValue(
            decimal value,
            string unitMeasurement)
        {
            Value = value;
            UnitMeasurement = unitMeasurement;
        }
    }
}
