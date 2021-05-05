using AutoMapper;
using Billing.Products.Application.SearchById;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using Billing.Products.Infrastructure.Mappings;
using BillingTest.Products.Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BillingTest.Products.Application.Search
{
    public class ProductsSearchByIdShould
    {
        private readonly Mock<IProductRepository> repository;
        private readonly Mapper mapper;
        private readonly ProductsSearchByIdManager searchByIdManager;
        public ProductsSearchByIdShould()
        {
            repository = new Mock<IProductRepository>();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() { new ProductProfile() });
            });
            mapper = new Mapper(mapperConfiguration);

            searchByIdManager = new ProductsSearchByIdManager(repository.Object, mapper);
        }

        [Fact]
        public void valid_search_by_id_products()
        {
            repository
                .Setup(rp => rp.GetById(1))
                .Returns(ProductMother.MartilloProductWithStock())
                .Verifiable();

            var product = searchByIdManager.Search(1);

            product
                .Should()
                .NotBeNull();

            repository.Verify();
        }

        [Fact]
        public void throw_not_found_search_by_id_products()
        {
            repository
                .Setup(rp => rp.GetById(1))
                .Returns(It.IsAny<Product>());

            Assert.Throws<ProductNotFound>(() => searchByIdManager.Search(1));

        }
    }
}
