using Billing.Invoices.Application;
using Billing.Invoices.Domain;
using Billing.Invoices.Domain.ValueObjects;
using BillingTest.Customers.Domain;
using BillingTest.Products.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingTest.Invoices.Domain
{
    public class InvoiceMother
    {
        public static Invoice StandardInvoice()
        {
            var invoice = new Invoice(
                DateTime.Now,
                DateTime.Now,
                new MonetaryValue(100000, "CO"),
                CustomerMother.Random());

            var product = ProductMother.MartilloProductWithStock();
            invoice.AddItem(
                name: product.Name,
                productId: product.Id,
                taxDescription: product.TaxDescription,
                unitPrice: product.Price,
                unitTax: product.Tax,
                quantity: new QuantityValue(2, "UM"));

            product = ProductMother.TaladroProductWithStock();
            invoice.AddItem(
                name: product.Name,
                productId: product.Id,
                taxDescription: product.TaxDescription,
                unitPrice: product.Price,
                unitTax: product.Tax,
                quantity: new QuantityValue(1, "UM"));

            return invoice;
        }
    }
}
