using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using CotizacionesPersonalesApi.Filters;
using CotizacionesPersonalesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CotizacionesPersonalesApi
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
            services.Configure<ClienteInfo>( Configuration.GetSection("Info"));

            // use in-memory  database for quik dev and testing 
            // TODO: Swap out for real database in production 
            services.AddDbContext<CotizacionesPersonalesApiDbContext>(options => options.UseInMemoryDatabase(databaseName : "cotizaciondb"));

            services
                .AddMvc(options => 
                {
                    options.Filters.Add<JsonExceptionFilter>();
                    options.Filters.Add<RequireHttpsOrCloseAttr>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting(Options => Options.LowercaseUrls = true);

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1,0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddSwaggerDocument();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp", policy => policy.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                // Register the Swagger generator and the Swagger UI middlewares
                app.UseSwagger();
                app.UseSwaggerUi3();
                
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowMyApp");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
