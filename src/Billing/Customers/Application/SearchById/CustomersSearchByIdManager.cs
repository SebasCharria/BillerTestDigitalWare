using AutoMapper;
using Billing.Customers.Domain;
using Billing.Customers.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Application.SearchById
{
    public class CustomersSearchByIdManager
    {
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;

        public CustomersSearchByIdManager(
            ICustomerRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public CustomerViewModel Search(int customerId)
        {
            var customer = repository.GetById(customerId);

            if (customer is null)
            {
                throw new CustomerNotFound();
            }

            return mapper.Map<CustomerViewModel>(customer);
        }

    }
}
