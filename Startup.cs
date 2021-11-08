using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApiEfCorePoc.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using WebApiEfCorePoc.Models.Helper;
using WebApiEfCorePoc.Repos;

namespace WebApiEfCorePoc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiEfCorePoc", Version = "v1" });
            });

            // Using ContextPool for re-using connection. However, bottleneck will still be DB level.
            services.AddDbContextPool<PaymentContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PaymentDb"))
            );

            // Registry AutoMapper.
            services.AddAutoMapper(typeof(PaymentAutomapperProfile));

            // IoC registry
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(_myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5001",
                            "http://localhost:5000");
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiEfCorePoc v1"));
                app.UseDeveloperExceptionPage();
                app.UseCors(_myAllowSpecificOrigins);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}