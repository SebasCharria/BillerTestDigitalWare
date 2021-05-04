using Billing.Customers.Application.Create;
using Billing.Customers.Application.SearchAll;
using Billing.Customers.Application.SearchById;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StartupModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Infrastructure.DependencyInjection.Customers
{
    public class Application : IStartupModule
    {
        public void Configure(IApplicationBuilder app, ConfigureMiddlewareContext context)
        {
        }

        public void ConfigureServices(IServiceCollection services, ConfigureServicesContext context)
        {
            services.AddTransient<CustomersSearchByIdManager>();
            services.AddTransient<CustomersSearchAllManager>();
            services.AddTransient<CustomersCreateManager>();
        }
    }
}
