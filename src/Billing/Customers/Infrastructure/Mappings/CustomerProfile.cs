using AutoMapper;
using Billing.Customers.Application;
using Billing.Customers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Customers.Infrastructure.Mappings
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
