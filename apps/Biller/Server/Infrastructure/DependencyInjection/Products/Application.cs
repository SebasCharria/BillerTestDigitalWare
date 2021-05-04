using Billing.Products.Application.AdjustStock;
using Billing.Products.Application.Create;
using Billing.Products.Application.Delete;
using Billing.Products.Application.SearchAll;
using Billing.Products.Application.SearchById;
using Billing.Products.Application.Update;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StartupModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Infrastructure.DependencyInjection.Products
{
    public class Application : IStartupModule
    {
        public void Configure(IApplicationBuilder app, ConfigureMiddlewareContext context)
        {
        }

        public void ConfigureServices(IServiceCollection services, ConfigureServicesContext context)
        {
            services.AddTransient<ProductsAdjustStockManager>();
            services.AddTransient<ProductsCreateManager>();
            services.AddTransient<ProductsSearchAllManager>();
            services.AddTransient<ProductsSearchByIdManager>();
            services.AddTransient<ProductsUpdateManager>();
            services.AddTransient<ProductsDeleteManager>();
        }
    }
}
