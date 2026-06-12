using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AppointmentBookingSystem.Domain.Options;
using Microsoft.Extensions.DependencyInjection;
using AppointmentBookingSystem.Domain.Interface;
using AppointmentBookingSystem.Infrastructure.Data;
using AppointmentBookingSystem.Infrastructure.Repository;

namespace AppointmentBookingSystem.Infrastructure
{
    public static class AppointmentBookingSystemRegister
    {
        public static IServiceCollection AddInfastractureDependancyInjections(this IServiceCollection services)
        {
            services.AddDbContext<AppointmentBookingSystemContext>((provider, option) =>
            {
                option.UseNpgsql(provider.GetRequiredService<IOptionsSnapshot<ConnectioStringOptions>>().Value.PostgressConnectionString);
            });

            services.AddScoped<DbContext, AppointmentBookingSystemContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
