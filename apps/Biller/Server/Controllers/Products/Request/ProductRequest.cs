using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Products.Request
{
    public class ProductRequest
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public MonetaryValue Price { get; set; }
        public MonetaryValue Tax { get; set; }
        public QuantityValue InitialStock { get; set; }
        public string TaxDescription { get; set; }
    }
}
