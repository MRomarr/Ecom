using Ecom.Application.Interfaces;
using Ecom.Infrastructure.Persistence;
using Ecom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenercRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            var connctionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("no conntecion string was found");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connctionString));

            return services;

            
        }
    }
}
