using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodDelivery.Repository;
using FoodDelivery.Models;

namespace FoodDelivery
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<FoodDeliveryContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("LocalConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["GCredential:ClientId"];
                googleOptions.ClientSecret = Configuration["GCredential:ClientSecret"];
            });

            services.AddTransient<IRepository<Customer>, CustomerRepository>();
            services.AddTransient<IRepository<DeliveryAddress>, DeliveryAddressRepository>();
            services.AddTransient<IRepository<OrderItem>, OrderItemRepository>();
            services.AddTransient<IRepository<OrderStatus>, OrderStatusRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<PaymentMethod>, PaymentMethodRepository>();
            services.AddTransient<IRepository<RestaurantMenu>, RestaurantMenuRepository>();
            services.AddTransient<IRepository<RestaurantMenuItem>, RestaurantMenuItemRepository>();
            services.AddTransient<IRepository<Restaurant>, RestaurantRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
