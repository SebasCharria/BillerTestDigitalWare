using Billing.Invoices.Domain;
using Billing.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Products.Application.AdjustStock
{
    public class ProductsAdjustStockManager
    {
        private readonly IProductRepository repository;
        private readonly IInvoiceRepository invoiceRepository;

        public ProductsAdjustStockManager(
            IProductRepository repository,
            IInvoiceRepository invoiceRepository)
        {
            this.repository = repository;
            this.invoiceRepository = invoiceRepository;
        }

        /// <summary>
        /// Caso de uso "Ajustar stock".
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void AdjustStock(int productId, QuantityValue quantity)
        {
            var product = repository.GetById(productId);
            product.AdjustStock(quantity);
            repository.Update(product);
        }

        /// <summary>
        /// Caso de uso "Ajustar Stock" por factura.
        /// <para> Este metodo retira la cantidad vendida de cada articulos del stock</para>
        /// </summary>
        /// <param name="invoiceId"></param>
        public void AdjustStock(int invoiceId)
        {
            var invoiceItems = invoiceRepository.GetAllItems(invoiceId);

            if (invoiceItems == null)
            {
                throw new InvalidOperationException("Invoice items not found");
            }

            List<Product> productsEdit = new List<Product>();
            foreach (var item in invoiceItems)
            {
                var product = item.Product;
                
                product.AdjustStock(new QuantityValue(item.Quantity.Value * (-1), item.Quantity.UnitMeasurement), "Sale");
                productsEdit.Add(product);
            }

            repository.Update(productsEdit);
        }

    }
}
