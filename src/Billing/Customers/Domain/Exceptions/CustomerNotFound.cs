using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Domain.Exceptions
{

    [Serializable]
    public class CustomerNotFound : Exception
    {
        public CustomerNotFound() { }
        public CustomerNotFound(string message) : base(message) { }
        public CustomerNotFound(string message, Exception inner) : base(message, inner) { }
        protected CustomerNotFound(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
