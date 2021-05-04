using AutoMapper;
using Billing.Products.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application.Create
{
    public class ProductsCreateManager
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductsCreateManager(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// caso de uso "Crear producto"
        /// </summary>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="friendlyName"></param>
        /// <param name="price"></param>
        /// <param name="tax"></param>
        /// <param name="initialStock"></param>
        /// <param name="taxDescription"></param>
        /// <returns></returns>
        public ProductViewModel Create(
            string description,
            string name,
            string friendlyName,
            MonetaryValue price,
            MonetaryValue tax,
            QuantityValue initialStock,
            string taxDescription)
        {
            var product = new Product(
                description: description,
                name: name,
                friendlyName: friendlyName,
                price: price,
                tax: tax,
                taxDescription: taxDescription);
            
            // Hace el primer ajuste.
            product.AdjustStock(initialStock, "Initial Stock");

            // Guarda el producto.
            repository.Insert(product);

            return mapper.Map<ProductViewModel>(product);
        }
    }
}
