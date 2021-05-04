using AutoMapper;
using Billing.Customers.Domain;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Application.Create
{
    public class CustomersCreateManager
    {
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;

        public CustomersCreateManager(
            ICustomerRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Caso de uso "Crear cliente"
        /// </summary>
        /// <param name="age"></param>
        /// <param name="email"></param>
        /// <param name="identifier"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public CustomerViewModel Create(
            int age,
            string email,
            IdentifierValue identifier,
            string name)
        {
            var customer = new Customer(
                age: age,
                email: email,
                identifier: identifier,
                name: name);

            repository.Insert(customer);
            return mapper.Map<CustomerViewModel>(customer);
        }
    }
}
