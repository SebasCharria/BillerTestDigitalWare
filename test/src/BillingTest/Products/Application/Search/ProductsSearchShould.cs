using AutoMapper;
using Billing.Products.Application.SearchAll;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using Billing.Products.Infrastructure.Mappings;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BillingTest.Products.Application.Search
{
    public class ProductsSearchShould
    {
        private readonly Mock<IProductRepository> repository;
        private readonly Mapper mapper;
        private readonly ProductsSearchAllManager searchAllManager;
        public ProductsSearchShould()
        {
            repository = new Mock<IProductRepository>();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() { new ProductProfile() });
            });
            mapper = new Mapper(mapperConfiguration);

            searchAllManager = new ProductsSearchAllManager(repository.Object, mapper);
        }
    
        [Fact]
        public void valid_searchall_products()
        {
            repository
                .Setup(rp => rp.Search())
                .Returns(Enumerable.Empty<Product>())
                .Verifiable();

            var products = searchAllManager.Search();

            products
                .Should()
                .NotBeNull();

            repository.Verify();
        }

        [Fact]
        public void throw_not_found_searchall_products()
        {
            repository
                .Setup(rp => rp.Search())
                .Returns(It.IsAny<IEnumerable<Product>>());

            Assert.Throws<ProductNotFound>(() => searchAllManager.Search());

        }

    }
}
