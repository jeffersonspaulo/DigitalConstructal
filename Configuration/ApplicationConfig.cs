using DigitalConstructal.Services.Interfaces;
using DigitalConstructal.Services;
using Microsoft.EntityFrameworkCore;
using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.Data.Repository;
using DigitalConstructal.Data;

namespace DigitalConstructal.Configuration
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

            services.AddDbContext<DigitalContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
