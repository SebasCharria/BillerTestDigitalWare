using AutoMapper;
using Billing.Products.Application;
using Billing.Products.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.Products.Infrastructure.Mappings
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
