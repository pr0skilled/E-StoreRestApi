using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Database;
using E_StoreRestApi.Infrastructure;
using E_StoreRestApi.Models.Shared;
using E_StoreRestApi.Repositories;
using E_StoreRestApi.Repositories.Implementations;
using E_StoreRestApi.Repositories.Interfaces;
using E_StoreRestApi.Services;
using E_StoreRestApi.Services.Implementations;
using E_StoreRestApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace E_StoreRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMemoryCache();

            services.AddSession();

            services.AddDistributedMemoryCache();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Building Materials E-Store", Version = "v1" });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });



            services.AddDbContext<EStoreDbContext>(options => options.UseSqlite(Configuration["Data:EStoreApi:ConnectionString"]));

            services.AddDbContext<EStoreIdentityDbContext>(options => options.UseSqlite(Configuration["Data:EStoreIdentity:ConnectionString"]));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<EStoreIdentityDbContext>();

            services.AddJwtAuth(Configuration);

            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();

            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICatalogueService, CatalogueService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICheckoutService, CheckoutService>();

            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Building Materials E-Store V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<EStoreIdentityDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                IdentityDbSeeder.Seed(dbContext, roleManager, userManager);
            }
        }

    }
}
