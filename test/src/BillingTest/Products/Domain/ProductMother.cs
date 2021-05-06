using Billing.Products.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BillingTest.Products.Domain
{
    public class ProductMother
    {
        public static Product Random()
        {
            var random = new Random();
            return new Product(
                    Path.GetTempFileName(),
                    Path.GetTempFileName(),
                    Path.GetTempFileName(),
                    new MonetaryValue(random.Next(1, 1000), "CO"),
                    new MonetaryValue(random.Next(1, 1000), "CO"),
                    Path.GetTempFileName());
        }

        public static Product StandardProductWith1000Stock()
        {
            var product = new Product(
                "Descripcion del martillo",
                "Martillo",
                "Martillo",
                new MonetaryValue(5000M, "CO"),
                new MonetaryValue(9500, "CO"),
                "Tax 19%");

            product.AdjustStock(
                new QuantityValue(1000, "UM"), "Initial Stock");
            
            return product;
        }

        public static Product MartilloProductWithStock()
        {
            var product = new Product(
                description: "Este es un martillo",
                name: "Martilllo",
                friendlyName: "Martillo",
                price: new MonetaryValue(100000, "CO"),
                tax: new MonetaryValue(19000, "CO"),
                taxDescription: "IVA 19%");

            product.AdjustStock(
                new QuantityValue(1000, "UM"), "Initial Stock");

            return product;

        }

        public static Product TaladroProductWithStock()
        {
            var product = new Product(
               description: "Este es un taladro",
               name: "Taladro",
               friendlyName: "Taladro",
               price: new MonetaryValue(50000, "CO"),
               tax: new MonetaryValue(9500, "CO"),
               taxDescription: "IVA 19%");

            product.AdjustStock(
                new QuantityValue(1000, "UM"), "Initial Stock");

            return product;
        }

        public static Product TaladroProductWitMinStock()
        {
            var minStockAllowed = 5; // Product.MIN_STOCK_ALLOWED
            var product = new Product(
               description: "Este es un taladro",
               name: "Taladro",
               friendlyName: "Taladro",
               price: new MonetaryValue(50000, "CO"),
               tax: new MonetaryValue(9500, "CO"),
               taxDescription: "IVA 19%");

            product.AdjustStock(
                new QuantityValue(minStockAllowed, "UM"), "Initial Stock");

            return product;
        }

        public static Product TaladroProductWith5Stock()
        {
            var product = new Product(
               description: "Este es un taladro",
               name: "Taladro",
               friendlyName: "Taladro",
               price: new MonetaryValue(50000, "CO"),
               tax: new MonetaryValue(9500, "CO"),
               taxDescription: "IVA 19%");

            product.AdjustStock(
                new QuantityValue(5, "UM"), "Initial Stock");

            return product;
        }
    }
}
