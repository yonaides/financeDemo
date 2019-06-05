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
using AutoMapper;
using CotizacionesPersonalesApi.AutoMapper;
using CotizacionesPersonalesApi.Services;
using Microsoft.AspNetCore.Identity;
using AspNet.Security.OpenIdConnect.Primitives;
using OpenIddict.Validation;

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
            services.Configure<PagingOptions>(Configuration.GetSection("DefaultPagingOptions"));

            services.AddScoped<IClienteService, DefaultClienteService>();
            services.AddScoped<IServicioService, DefaultServicioService>();
            services.AddScoped<IDetalleServicioService, DefaultDetalleServicioService>();
            services.AddScoped<IUserService, DefaultUserService>();

            // use in-memory  database for quik dev and testing 
            // TODO: Swap out for real database in production 
            services.AddDbContext<CotizacionesPersonalesApiDbContext>(options => {
                options.UseInMemoryDatabase(databaseName: "cotizaciondb");
                options.UseOpenIddict<Guid>();
                });

            // Add OpenIddict services
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<CotizacionesPersonalesApiDbContext>()
                        .ReplaceDefaultEntities<Guid>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();

                    options.EnableTokenEndpoint("/token");

                    options.AllowPasswordFlow();
                    options.AcceptAnonymousClients();
                })
                .AddValidation();

            // ASP.NET Core Identity should use the same claim names as OpenIddict
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OpenIddictValidationDefaults.AuthenticationScheme;
            });


            // agregando UserIdentity
            AddIdentityCoreServices(services);

            services
                .AddMvc(options => 
                {
                    options.Filters.Add<JsonExceptionFilter>();
                    options.Filters.Add<RequireHttpsOrCloseAttr>();
                    options.Filters.Add<LinkRewritingFilter>();
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

            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());


            services.Configure<ApiBehaviorOptions>(options => 
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errorResponse = new ApiError(context.ModelState);
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            services.AddResponseCaching();
            services.AddAuthorization(options => {
                options.AddPolicy("ViewAllUsersPolicy", p => p.RequireAuthenticatedUser().RequireRole("Admin"));
            });

        }

        private void AddIdentityCoreServices(IServiceCollection services)
        {
            var builder = services.AddIdentityCore<UserEntity>();
            builder = new IdentityBuilder(builder.UserType, typeof(UserRoleEntity), builder.Services);

            builder
                .AddRoles<UserRoleEntity>()
                .AddEntityFrameworkStores<CotizacionesPersonalesApiDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<UserEntity>>();


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

            app.UseAuthentication();
            app.UseResponseCaching();
            app.UseCors("AllowMyApp");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
