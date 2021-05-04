using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Invoices.Domain.Exceptions
{

    [Serializable]
    public class InvoiceNotFound : Exception
    {
        public InvoiceNotFound() { }
        public InvoiceNotFound(string message) : base(message) { }
        public InvoiceNotFound(string message, Exception inner) : base(message, inner) { }
        protected InvoiceNotFound(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
