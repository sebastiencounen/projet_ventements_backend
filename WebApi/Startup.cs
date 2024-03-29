using Application;
using Application.Repositories;
using Application.Services.Addresses;
using Application.Services.BaggedItems;
using Application.Services.Categories;
using Application.Services.Items;
using Application.Services.OrderedItems;
using Application.Services.Orders;
using Application.Services.Reviews;
using Application.Services.Users;
using Application.Services.WishLists;
using Infrastructure.SqlServer.Addresses;
using Infrastructure.SqlServer.BaggedItems;
using Infrastructure.SqlServer.Categories;
using Infrastructure.SqlServer.Items;
using Infrastructure.SqlServer.OrderedItems;
using Infrastructure.SqlServer.Orders;
using Infrastructure.SqlServer.Reviews;
using Infrastructure.SqlServer.Users;
using Infrastructure.SqlServer.WishLists;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Helpers;

namespace WebApi
{
    public class Startup
    {
        readonly string CorsPolicyName = "MyPolicy";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
                options.AddPolicy(CorsPolicyName, 
                    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            // Dependency injection
            services.AddSingleton<IPasswordEncryption, PasswordEncryption>();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IAddressRepository, AddressRepository>();
            services.AddSingleton<IAddressService, AddressService>();

            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IItemRepository, ItemRepository>();

            services.AddSingleton<IReviewService, ReviewService>();
            services.AddSingleton<IReviewRepository, ReviewRepository>();

            services.AddSingleton<IBaggedItemService, BaggedItemService>();
            services.AddSingleton<IBaggedItemRepository, BaggedItemRepository>();

            services.AddSingleton<IWishListService, WishListService>();
            services.AddSingleton<IWishListRepository, WishListRepository>();

            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderService, OrderService>();

            services.AddSingleton<IOrderedItemRepository, OrderedItemRepository>();
            services.AddSingleton<IOrderedItemService, OrderedItemService>();

            // Swagger api documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ventements API",
                    Version = "v1",
                    Description = "API of Ventements which is an E-Commerce school project site"
                });
                c.CustomSchemaIds(type => type.ToString());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }

            app.UseCors(CorsPolicyName);

            // Swagger API Documentation
            app.UseSwagger(c => { c.SerializeAsV2 = true; });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ventements API Documentation");
                c.RoutePrefix = "api/documentation";
            });
            //

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}