using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymManagement.Infrastructure.Gyms.Persistence;

namespace GymManagement.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<GymManagementDbContext>(options =>
            options.UseSqlite("Data Source = GymManagement.db"));

        // services.AddScoped<IAdminsRepository, AdminsRepository>();
        services.AddScoped<IGymsRepository, GymsRepository>();
        services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GymManagementDbContext>());
        return services;
    }
}