using Billing.Shared.Infrastructure.Persistence.EfCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Infrastructure.Mvc.JsonConverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddProblemDetails(op =>
                {
                    op.IncludeExceptionDetails = (ctx, ex) => true;
                })
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new MonetaryValueConverter());
                    options.SerializerSettings.Converters.Add(new QuantityValueConverter());
                    options.SerializerSettings.Converters.Add(new IdentifierValueConverter());
                });

            services.AddDbContext<BillingDbContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("billing"));
            });

            services.AddAutoMapper(typeof(Startup).Assembly, typeof(BillingDbContext).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseProblemDetails();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
