using Shared.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Value;

namespace Shared.Domain.ValueObjects
{
    public class IdentifierValue: ValueObject
    {
        public TaxIdentifier TaxIdentifier { get; private set; }
        public string Value { get; private set; }

        protected IdentifierValue()
        {
        }

        public IdentifierValue(
            TaxIdentifier taxIdentifier,
            string value)
        {
            TaxIdentifier = taxIdentifier;
            Value = value;
        }
    }
}
