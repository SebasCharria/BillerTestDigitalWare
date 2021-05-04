using Billing.Customers.Domain;
using Billing.Invoices.Domain.ValueObjects;
using Billing.Products.Domain;
using Shared.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Invoices.Domain
{
    public class Invoice : Entity, IAggregateRoot
    {
        public CustomerDetails CustomerDetails { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public MonetaryValue TotalReceived { get; private set; }
        public int TotalItems { get; private set; }
        public MonetaryValue TotalPrice { get; private set; }
        public readonly List<InvoiceItem> _items = new List<InvoiceItem>();
        public IEnumerable<InvoiceItem> Items => _items.AsReadOnly();

        protected Invoice()
        {
        }

        public Invoice(
            DateTime date,
            DateTime expirationDate,
            MonetaryValue totalReceived,
            Customer customer)
        {
            Date = date;
            ExpirationDate = expirationDate;
            TotalReceived = totalReceived;

            AddCustomerDetails(customer);
        }

        public void RefreshTotalPrice()
        {
            TotalPrice = new MonetaryValue(
                _items?.Sum(l => l.TotalPrice.Value) ?? 0, 
                _items?.FirstOrDefault()?.UnitPrice.Currency ?? string.Empty);
        }

        public void RefreshTotalItems()
        {
            TotalItems = _items?.Count ?? 0;
        }

        public void AddItem(
            string name,
            int productId,
            string taxDescription,
            MonetaryValue unitPrice,
            MonetaryValue unitTax,
            QuantityValue quantity)
        {

            var invoiceItem = new InvoiceItem(
                name: name,
                productId: productId,
                taxDescription: taxDescription,
                unitPrice: unitPrice,
                unitTax: unitTax,
                quantity: quantity);

            _items?.Add(invoiceItem);

            RefreshTotalItems();
            RefreshTotalPrice();
        }

        public void AddCustomerDetails(Customer customer)
        {
            var customerDetails = new CustomerDetails(
                age: customer.Age,
                identifier: customer.Identifier,
                name: customer.Name,
                customerId: customer.Id);
            CustomerDetails = customerDetails;
        }

    }
}
