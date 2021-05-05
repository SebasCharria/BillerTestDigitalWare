using AutoMapper;
using Billing.Products.Application.Update;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using Billing.Products.Infrastructure.Mappings;
using BillingTest.Products.Domain;
using FluentAssertions;
using Moq;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BillingTest.Products.Application.Update
{
    public class ProductsUpdateShould
    {
        private readonly Mock<IProductRepository> repository;
        private readonly Mapper mapper;
        private readonly ProductsUpdateManager updateManager;

        public ProductsUpdateShould()
        {
            repository = new Mock<IProductRepository>();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() { new ProductProfile() });
            });
            mapper = new Mapper(mapperConfiguration);

            updateManager = new ProductsUpdateManager(repository.Object, mapper);
        }

        [Fact]
        public void valid_update_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository
                .Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(product);

            repository
                .Setup(rp => rp.Update(It.IsAny<Product>()))
                .Verifiable();

            // act
            updateManager.Update(product.Id);

            // val
            repository.Verify();
        }

        [Fact]
        public void valid_update_throw_not_found_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository
                .Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(It.IsAny<Product>());

            // act - Val
            Assert.Throws<ProductNotFound>(() => updateManager.Update(product.Id));

        }

        [Fact]
        public void valid_update_description_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository.Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(product);
            var newDescription = "Nueva descripcion";

            // act
            var productUpdate = updateManager.Update(product.Id, description: newDescription);

            productUpdate
                .Description
                .Should()
                .Be(newDescription);
        }

        [Fact]
        public void valid_update_name_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository.Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(product);
            var newName = "Martillo 2";

            // act
            var productUpdate = updateManager.Update(product.Id, name: newName);

            productUpdate
                .Name
                .Should()
                .Be(newName);
        }

        [Fact]
        public void valid_update_friendlyName_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository.Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(product);
            var newFriendlyName = "Martillo 2";

            // act
            var productUpdate = updateManager.Update(product.Id, friendlyName: newFriendlyName);

            productUpdate
                .FriendlyName
                .Should()
                .Be(newFriendlyName);
        }

        [Fact]
        public void valid_update_price_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository.Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(product);
            var newPrice = new MonetaryValue(100, "CO");

            // act
            var productUpdate = updateManager.Update(product.Id, price: newPrice);

            productUpdate
                .Price
                .Should()
                .Be(newPrice);
        }

        [Fact]
        public void valid_update_tax_product()
        {
            // setp
            var product = ProductMother.MartilloProductWithStock();
            repository.Setup(rp => rp.GetById(It.IsAny<int>()))
                .Returns(product);
            var newTax = new MonetaryValue(100, "CO");
            var taxDescription = "IVA 20% UP";

            // act
            var productUpdate = updateManager.Update(product.Id, tax: newTax, taxDescription: taxDescription);

            productUpdate
                .Tax
                .Should()
                .Be(newTax);

            productUpdate
                .TaxDescription
                .Should()
                .Be(taxDescription);
        }
    }
}
