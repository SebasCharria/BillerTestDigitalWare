using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Domain.Exceptions
{

    [Serializable]
    public class OutStock : Exception
    {
        private static readonly string message = "Product {0} - {1} Out Stock. Min Allowed: {2}";
        public OutStock(int productId, string productName) 
            : base(string.Format(message, productId, productName, Product.MIN_STOCK_ALLOWED)) { }
        protected OutStock(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
