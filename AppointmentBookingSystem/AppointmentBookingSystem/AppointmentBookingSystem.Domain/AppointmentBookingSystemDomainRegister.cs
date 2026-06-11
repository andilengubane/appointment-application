using Microsoft.Extensions.Configuration;
using AppointmentBookingSystem.Domain.Options;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBookingSystem.Domain
{
    public static class AppointmentBookingSystemDomainRegister
    {
        public static IServiceCollection AddDomainDependacyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectioStringOptions>(configuration.GetSection(ConnectioStringOptions.SectionName));
            return services;
        }
    }
}