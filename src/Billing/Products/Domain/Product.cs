using Billing.Products.Domain.ValueObjects;
using Shared.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Domain
{
    public class Product: Entity, IAggregateRoot
    {
        public string Description { get; private set; }
        public string Name { get; private set; }
        public string FriendlyName { get; private set; }
        public MonetaryValue Price { get; private set; }
        public QuantityValue StockQuantity { get; private set; }
        public MonetaryValue Tax { get; private set; }
        public string TaxDescription { get; private set; }
        public readonly List<StockQuantityHistory> _stockQuantityHistories = new List<StockQuantityHistory>();
        public IEnumerable<StockQuantityHistory> StockQuantityHistories => _stockQuantityHistories.AsReadOnly();

        protected Product()
        {
        }

        public Product(
            string description,
            string name,
            string friendlyName,
            MonetaryValue price,
            MonetaryValue tax,
            string taxDescription)
        {
            Description = description;
            Name = name;
            FriendlyName = friendlyName;
            Price = price;
            Tax = tax;
            TaxDescription = taxDescription;
            StockQuantity = new QuantityValue(0, string.Empty);
        }

        /// <summary>
        /// Ajusta la existecia.
        /// <para>Se aceptan valores negativos</para>
        /// </summary>
        /// <param name="quantity"></param>
        public void AdjustStock(QuantityValue quantity, string message = "Manual Adjustment")
        {
            if (quantity is null)
            {
                throw new ArgumentNullException(nameof(quantity));
            }

            var newQuantity = new QuantityValue(
                value: StockQuantity.Value + quantity.Value,
                unitMeasurement: quantity.UnitMeasurement);

            StockQuantity = newQuantity;

            var stockHistory = new StockQuantityHistory(
                date: DateTime.Now, 
                message: message, 
                quantityAdjustment: quantity, 
                stockQuantity: StockQuantity);

            _stockQuantityHistories.Add(stockHistory);

        }

        public Product ChangeDescription(string description)
        {
            if(description != null) Description = description;
            return this;
        }
        public Product ChangeName(string name)
        {
            if(name != null) Name = name;
            return this;
        }
        public Product ChangeFriendlyName(string friendlyName)
        {
            if(friendlyName != null) FriendlyName = friendlyName;
            return this;
        }
        public Product ChangePrice(MonetaryValue price)
        {
            if (price != null) Price = price;
            return this;
        }
        public Product ChangeTax(MonetaryValue tax, string taxDescription)
        {
            if (taxDescription != null)TaxDescription = taxDescription;
            if(tax != null) Tax = tax;
            return this;
        }

    }
}
