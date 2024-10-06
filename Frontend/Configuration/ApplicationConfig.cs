using DigitalConstructalWeb.Services.Interfaces;
using DigitalConstructalWeb.Services;
using Microsoft.EntityFrameworkCore;
using DigitalConstructalWeb.Data.Repository.Interfaces;
using DigitalConstructalWeb.Data.Repository;
using DigitalConstructalWeb.Data;

namespace DigitalConstructalWeb.Configuration
{
    public static class ApplicationConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddDbContext<DigitalContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
