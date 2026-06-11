using AppointmentBookingSystem.Domain;
using AppointmentBookingSystem.Application;
using AppointmentBookingSystem.Infrastructure;

namespace AppointmentBookingSystem.Api
{
    public static class AppointmentBookingSystemApiRegister
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDependacyInjection()
                    .AddInfastractureDependancyInjections()
                    .AddDomainDependacyInjection(configuration);

            return services;
        }
    }
}