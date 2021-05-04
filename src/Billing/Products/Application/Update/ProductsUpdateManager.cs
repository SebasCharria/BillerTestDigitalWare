using AutoMapper;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application.Update
{
    public class ProductsUpdateManager
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductsUpdateManager(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Actualizar un producto"
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="friendlyName"></param>
        /// <param name="price"></param>
        /// <param name="tax"></param>
        /// <param name="taxDescription"></param>
        /// <returns></returns>
        public ProductViewModel Update(
            int productId,
            string description = null,
            string name = null,
            string friendlyName = null,
            MonetaryValue price = null,
            MonetaryValue tax = null,
            string taxDescription = null)
        {
            var product = repository.GetById(productId);

            if (product == null)
            {
                throw new ProductNotFound();
            }

            product
                .ChangeDescription(description)
                .ChangeName(name)
                .ChangeFriendlyName(friendlyName)
                .ChangePrice(price)
                .ChangeTax(tax, taxDescription);

            repository.Update(product);

            return mapper.Map<ProductViewModel>(product);
        }
    }
}
