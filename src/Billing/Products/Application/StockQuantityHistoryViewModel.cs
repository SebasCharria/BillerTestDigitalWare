using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application
{
    public class StockQuantityHistoryViewModel
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public QuantityValue QuantityAdjustment { get; set; }
        public QuantityValue StockQuantity { get; set; }
    }
}
