using Billing.Products.Application.Delete;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using BillingTest.Products.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BillingTest.Products.Application.Delete
{
    public class ProductsDeleteShould
    {
        private readonly Mock<IProductRepository> repository;
        private readonly ProductsDeleteManager deleteManager;
        public ProductsDeleteShould()
        {
            repository = new Mock<IProductRepository>();
            deleteManager = new ProductsDeleteManager(repository.Object);
        }

        [Fact]
        public void valid_delete_product()
        {
            repository
                .Setup(rp => rp.GetById(1))
                .Returns(ProductMother.MartilloProductWithStock());

            // act
            deleteManager.Delete(1);

            //
            repository.Verify(rp => rp.Delete(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void throw_not_found_product()
        {
            repository
                .Setup(rp => rp.GetById(1))
                .Returns(It.IsAny<Product>());

            // act - val
            Assert.Throws<ProductNotFound>(() => deleteManager.Delete(1));

        }
    }
}
