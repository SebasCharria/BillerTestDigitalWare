using Shared.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Value;

namespace Billing.Products.Domain
{
    public class StockQuantityHistory : Entity
    {
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public QuantityValue QuantityAdjustment { get; private set; }
        public QuantityValue StockQuantity { get; private set; }

        protected StockQuantityHistory()
        {
        }

        public StockQuantityHistory(
            DateTime date,
            string message,
            QuantityValue quantityAdjustment,
            QuantityValue stockQuantity)
        {
            Date = date;
            Message = message;
            QuantityAdjustment = quantityAdjustment;
            StockQuantity = stockQuantity;
        }
    }
}
