using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using Furniture_System_Api.Configuration.Context;
using Microsoft.EntityFrameworkCore;
using Furniture_System_Api.Services.ProductService;
using Furniture_System_Api.Repository;
using Furniture_System_Api.Services;
using Furniture_System_Api.Services.SubComponent;

namespace FantasyLeague.Context
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("FurnitureDbConnectionString"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
           
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IComponentRepository, ComponentRepository>();
            services.AddScoped<IComponentService, ComponentService>();
            services.AddScoped<ISubComponentRepository, SubComponentServiceRepository>();
            services.AddScoped<ISubComponentService, SubComponentService>();


            return services;
        }
    }
}
