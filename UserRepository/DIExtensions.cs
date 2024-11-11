using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Promomash.UserRepository.Repository;

namespace Promomash.UserRepository
{
    public static class DIExtensions
    {
        public static IServiceCollection RegisterUserRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton(NaiveMapperInitializer.Create());
            services.AddScoped<IUserRepository, Repository.UserRepository>();

            return services;
        }
    }
}
