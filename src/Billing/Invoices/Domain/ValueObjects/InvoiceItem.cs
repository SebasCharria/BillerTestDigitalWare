using Billing.Products.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Value;

namespace Billing.Invoices.Domain.ValueObjects
{
    public class InvoiceItem : ValueObject
    {
        public string Name { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public QuantityValue Quantity { get; private set; }
        public string TaxDescription { get; private set; }
        public MonetaryValue TotalPrice { get; private set; }
        public MonetaryValue UnitPrice { get; private set; }
        public MonetaryValue UnitTax { get; private set; }

        protected InvoiceItem()
        {
        }

        public InvoiceItem(
            string name,
            int productId,
            string taxDescription,
            MonetaryValue unitPrice,
            MonetaryValue unitTax,
            QuantityValue quantity)
        {
            Name = name;
            ProductId = productId;
            Quantity = quantity;
            TaxDescription = taxDescription;
            UnitTax = unitTax;
            UnitPrice = unitPrice;
            ComputeTotalPrice();
        }

        protected void ComputeTotalPrice()
        {
            if (UnitPrice != null & Quantity != null)
            {
                TotalPrice =
                    new MonetaryValue(UnitPrice.Value * Quantity.Value, UnitPrice.Currency);
            }
        }
    }
}
