using AutoMapper;
using Billing.Products.Domain;
using Billing.Products.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Application.SearchAll
{
    public class ProductsSearchAllManager
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductsSearchAllManager(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Consultar producto"
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> Search()
        {
            var products = repository.Search();

            if (products == null)
            {
                throw new ProductNotFound();
            }

            return mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}
