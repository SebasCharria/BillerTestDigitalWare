using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public MonetaryValue Price { get; set; }
        public QuantityValue StockQuantity { get; set; }
        public MonetaryValue Tax { get; set; }
        public string TaxDescription { get; set; }
        public List<StockQuantityHistoryViewModel> StockQuantityHistories { get; set; }
    }
}
