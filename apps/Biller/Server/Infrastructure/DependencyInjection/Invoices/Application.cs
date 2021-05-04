using Billing.Invoices.Application.Create;
using Billing.Invoices.Application.Delete;
using Billing.Invoices.Application.SearchAll;
using Billing.Invoices.Application.SearchById;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StartupModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Infrastructure.DependencyInjection.Invoices
{
    public class Application : IStartupModule
    {
        public void Configure(IApplicationBuilder app, ConfigureMiddlewareContext context)
        {
        }

        public void ConfigureServices(IServiceCollection services, ConfigureServicesContext context)
        {
            services.AddTransient<InvoicesCreateManager>();
            services.AddTransient<InvoicesSearchAllManager>();
            services.AddTransient<InvoicesSearchByIdManager>();
            services.AddTransient<InvoicesDeleteManager>();
        }
    }
}
