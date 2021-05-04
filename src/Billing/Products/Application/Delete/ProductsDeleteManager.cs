using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application.Delete
{
    public class ProductsDeleteManager
    {
        private readonly IProductRepository repository;

        public ProductsDeleteManager(
            IProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Caso de uso "Eliminar un producto"
        /// </summary>
        /// <param name="productId"></param>
        public void Delete(int productId)
        {
            var product = repository.GetById(productId);
            if (product == null)
            {
                throw new ProductNotFound();
            }

            repository.Delete(product);

        }
    }
}
