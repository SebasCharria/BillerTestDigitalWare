using AutoMapper;
using Billing.Invoices.Domain;
using Billing.Products.Application;
using Billing.Products.Application.Create;
using Billing.Products.Domain;
using Billing.Products.Infrastructure.Mappings;
using BillingTest.Products.Domain;
using FluentAssertions;
using Moq;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BillingTest.Products.Application.Create
{
    public class ProductsCreateShould
    {
        private readonly Mock<IProductRepository> repository;
        private readonly Mapper mapper;
        private readonly ProductsCreateManager createManager;

        public ProductsCreateShould()
        {
            repository = new Mock<IProductRepository>();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() { new ProductProfile() });
            });
            mapper = new Mapper(mapperConfiguration);

            createManager = new ProductsCreateManager(repository.Object, mapper);
        }
        
        [Fact]
        public void valid_insert_product()
        {
            // setp
            repository
                .Setup(rp => rp.Insert(It.IsAny<Product>()))
                .Verifiable();

            var productRandom = ProductMother.MartilloProductWithStock();

            // act
            var productCreate = createManager.Create(
                description: productRandom.Description,
                name: productRandom.Name,
                friendlyName: productRandom.FriendlyName,
                price: productRandom.Price,
                tax: productRandom.Tax,
                initialStock: new QuantityValue(100, "UM"),
                taxDescription: productRandom.TaxDescription)

            // val
                .Should()
                .BeOfType<ProductViewModel>();

            repository.Verify();
        }

        [Fact]
        public void valid_initial_stock_product()
        {
            // setp
            repository
                .Setup(rp => rp.Insert(It.IsAny<Product>()));

            var productRandom = ProductMother.MartilloProductWithStock();
            var initialQuantity = new QuantityValue(100, "UM");

            // act
            var productCreate = createManager.Create(
                description: productRandom.Description,
                name: productRandom.Name,
                friendlyName: productRandom.FriendlyName,
                price: productRandom.Price,
                tax: productRandom.Tax,
                initialStock: initialQuantity,
                taxDescription: productRandom.TaxDescription);

            // val
            productCreate
                .Should()
                .NotBeNull();

            productCreate
                .StockQuantity
                .Should().Be(initialQuantity);

            productCreate
                .StockQuantityHistories
                .Should()
                .NotBeEmpty();

            var firstHistory = productCreate.StockQuantityHistories.FirstOrDefault();
            firstHistory
                .Should()
                .NotBeNull();

            firstHistory
                .QuantityAdjustment
                .Should()
                .Be(initialQuantity);

            repository.Verify();
        }
    }
}
