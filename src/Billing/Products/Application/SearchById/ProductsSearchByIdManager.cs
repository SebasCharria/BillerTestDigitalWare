using AutoMapper;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application.SearchById
{
    public class ProductsSearchByIdManager
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductsSearchByIdManager(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Consultar producto" por su id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductViewModel Search(int productId)
        {
            var product = repository.GetById(productId);

            if (product == null)
            {
                throw new ProductNotFound();
            }

            return mapper.Map<ProductViewModel>(product);
        }
    }
}
