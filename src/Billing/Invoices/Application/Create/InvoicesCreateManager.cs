using AutoMapper;
using Billing.Customers.Application.SearchById;
using Billing.Customers.Domain;
using Billing.Customers.Domain.Exceptions;
using Billing.Invoices.Domain;
using Billing.Products.Application.AdjustStock;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Invoices.Application.Create
{
    public class InvoicesCreateManager
    {
        private readonly IInvoiceRepository repository;
        private readonly IProductRepository productRepository;
        private readonly ProductsAdjustStockManager adjustStockManager;
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public InvoicesCreateManager(
            IInvoiceRepository repository,
            IProductRepository productRepository,
            ProductsAdjustStockManager adjustStockManager,
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.adjustStockManager = adjustStockManager;
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Crear factura"
        /// </summary>
        /// <param name="date"></param>
        /// <param name="expirationDate"></param>
        /// <param name="totalReceived"></param>
        /// <param name="productInputs"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="CustomerNotFound"></exception>
        /// <exception cref="ProductNotFound"></exception>
        public InvoiceViewModel Create(
            DateTime date,
            DateTime expirationDate,
            MonetaryValue totalReceived,
            int customerId,
            IEnumerable<ProductInputModel> productInputs)
        {

            var customer = customerRepository.GetById(customerId);

            if (customer is null)
            {
                throw new CustomerNotFound();
            }

            // se crea la factura
            var invoice = new Invoice(
                date: date,
                expirationDate: expirationDate,
                totalReceived: totalReceived,
                customer: customer);

            // se agregan los productos.
            foreach (var productInput in productInputs)
            {
                var product = productRepository.GetById(productInput.ProductId);

                if (product == null)
                {
                    throw new ProductNotFound();
                }

                invoice.AddItem(
                    name: product.Name,
                    productId: product.Id,
                    taxDescription: product.TaxDescription,
                    unitPrice: product.Price,
                    unitTax: product.Tax,
                    quantity: productInput.Quantity);

                product.AdjustStock(
                    new QuantityValue(productInput.Quantity.Value * (-1), productInput.Quantity.UnitMeasurement),
                    "Sale");
            }

            repository.Insert(invoice);

            return mapper.Map<InvoiceViewModel>(invoice);
        }
    }
}
