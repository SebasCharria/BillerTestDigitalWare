using AutoMapper;
using Billing.Customers.Domain;
using Billing.Customers.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Application.SearchAll
{
    public class CustomersSearchAllManager
    {
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;

        public CustomersSearchAllManager(
            ICustomerRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Consultar clientes"
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerViewModel> Search()
        {
            var customers = repository.Search();
            if (customers is null)
            {
                throw new CustomerNotFound();
            }

            return mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        }
    }
}
