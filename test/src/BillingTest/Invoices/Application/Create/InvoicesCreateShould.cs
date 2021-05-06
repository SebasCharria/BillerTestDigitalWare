using AutoMapper;
using Billing.Customers.Domain;
using Billing.Invoices.Domain;
using Billing.Invoices.Infrastructure.Mappings;
using Billing.Products.Domain;
using BillingTest.Customers.Domain;
using BillingTest.Products.Domain;
using Moq;
using Shared.Domain.Enums;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Linq;
using Billing.Invoices.Application;
using Billing.Invoices.Application.Create;
using Billing.Customers.Domain.Exceptions;
using Billing.Products.Domain.Exceptions;

namespace BillingTest.Invoices.Application.Create
{
    public class InvoicesCreateShould
    {
        private readonly Mock<IInvoiceRepository> invoiceRepository;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<ICustomerRepository> customerRepository;
        private readonly IMapper mapper;
        private readonly InvoicesCreateManager createManager;

        public InvoicesCreateShould()
        {
            invoiceRepository = new Mock<IInvoiceRepository>();
            productRepository = new Mock<IProductRepository>();
            customerRepository = new Mock<ICustomerRepository>();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() { new InvoiceProfile() });
            });
            mapper = new Mapper(mapperConfiguration);

            createManager = new InvoicesCreateManager(
                invoiceRepository.Object, productRepository.Object, customerRepository.Object, mapper);
        }

        [Fact]
        public void valid_insert_invoice()
        {
            // setp
            var products = new List<ProductInputModel>()
            {
                new ProductInputModel()
                {
                    ProductId = 1,
                    Quantity = new QuantityValue(1, "UM"),
                }
            };

            customerRepository
                .Setup(cr => cr.GetById(1))
                .Returns(CustomerMother.Random())
                .Verifiable();

            productRepository
                .Setup(pr => pr.GetById(It.IsAny<int>()))
                .Returns(ProductMother.StandardProductWith1000Stock())
                .Verifiable();

            // act
            createManager.Create(
                date: DateTime.Now,
                expirationDate: DateTime.Now.AddDays(2),
                totalReceived: new MonetaryValue(100, "CO"),
                customerId: 1,
                productInputs: products)

                // valitation
                .Should().As<InvoiceViewModel>();

            productRepository.Verify();
            productRepository.Verify();
            productRepository.Verify(pr => pr.Update(It.IsAny<IEnumerable<Product>>()), Times.AtLeastOnce);
            invoiceRepository.Verify(re => re.Insert(It.IsAny<Invoice>()), Times.AtLeastOnce);
        }

        [Fact]
        public void valid_adjust_products_stock()
        {
            // setp
            customerRepository
                .Setup(cr => cr.GetById(1))
                .Returns(CustomerMother.Random());

            productRepository
                .Setup(pr => pr.GetById(1))
                .Returns(ProductMother.StandardProductWith1000Stock());

            var productsUpdates = new List<Product>();
            productRepository
                .Setup(pr => pr.Update(It.IsAny<IEnumerable<Product>>()))
                .Callback<IEnumerable<Product>>(products =>
                {
                    productsUpdates.AddRange(products);
                });

            var products = new List<ProductInputModel>()
            {
                new ProductInputModel()
                {
                    ProductId = 1,
                    Quantity = new QuantityValue(10, "UM"),
                }
            };

            // act
            var invoice = createManager.Create(
                date: DateTime.Now,
                expirationDate: DateTime.Now.AddDays(2),
                totalReceived: new MonetaryValue(100, "CO"),
                customerId: 1,
                productInputs: products);

            // val
            foreach (var item in invoice.Items)
            {
                var stockExpected = new QuantityValue(
                    ProductMother.StandardProductWith1000Stock().StockQuantity.Value - item.Quantity.Value, "UM");

                var product = productsUpdates.FirstOrDefault(p => p.Id == item.ProductId);

                product
                    .Should()
                    .NotBeNull();

                product
                    .StockQuantity
                    .Should()
                    .Be(stockExpected);
            }

        }

        [Fact]
        public void throw_customer_not_found()
        {
            // setp
            customerRepository
                .Setup(cr => cr.GetById(1))
                .Returns(It.IsAny<Customer>());

            var products = new List<ProductInputModel>()
            {
                new ProductInputModel()
                {
                    ProductId = 1,
                    Quantity = new QuantityValue(10, "UM"),
                }
            };

            // act - val
            Assert.Throws<CustomerNotFound>(() => createManager.Create(
                date: DateTime.Now,
                expirationDate: DateTime.Now.AddDays(2),
                totalReceived: new MonetaryValue(100, "CO"),
                customerId: 1,
                productInputs: products));

        }

        [Fact]
        public void throw_product_not_found()
        {
            // setp
            customerRepository
                .Setup(cr => cr.GetById(1))
                .Returns(CustomerMother.Random());

            productRepository
                .Setup(pr => pr.GetById(1))
                .Returns(It.IsAny<Product>());

            var products = new List<ProductInputModel>()
            {
                new ProductInputModel()
                {
                    ProductId = 1,
                    Quantity = new QuantityValue(10, "UM"),
                }
            };

            // act - val
            Assert.Throws<ProductNotFound>(() => createManager.Create(
                date: DateTime.Now,
                expirationDate: DateTime.Now.AddDays(2),
                totalReceived: new MonetaryValue(100, "CO"),
                customerId: 1,
                productInputs: products));
        }

        [Fact]
        public void throw_outstock_invoice()
        {
            // setp
            customerRepository
                .Setup(cr => cr.GetById(1))
                .Returns(CustomerMother.Random());

            productRepository
                .Setup(pr => pr.GetById(1))
                .Returns(ProductMother.TaladroProductWitMinStock());

            var products = new List<ProductInputModel>()
            {
                new ProductInputModel()
                {
                    ProductId = 1,
                    Quantity = new QuantityValue(10, "UM"),
                }
            };

            // act - val
            Assert.Throws<OutStock>(() => createManager.Create(
                date: DateTime.Now,
                expirationDate: DateTime.Now.AddDays(2),
                totalReceived: new MonetaryValue(100, "CO"),
                customerId: 1,
                productInputs: products));
        }
    }
}
