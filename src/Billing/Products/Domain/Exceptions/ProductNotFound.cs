using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Domain.Exceptions
{

    [Serializable]
    public class ProductNotFound : Exception
    {
        public ProductNotFound() { }
        public ProductNotFound(string message) : base(message) { }
        public ProductNotFound(string message, Exception inner) : base(message, inner) { }
        protected ProductNotFound(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
