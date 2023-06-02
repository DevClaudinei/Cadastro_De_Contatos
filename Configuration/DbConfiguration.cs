using ContactRegister.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactRegister.Configuration;

public static class DbConfiguration
{
    public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContactContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly("ContactRegister"));
        }, contextLifetime: ServiceLifetime.Transient);
    }
}