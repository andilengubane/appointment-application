using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBookingSystem.Application
{
    public static class AppointmentBookingSystemApplicationRegister
    {
        public static IServiceCollection AddApplicationDependacyInjection(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AppointmentBookingSystemApplicationRegister).Assembly);
                cfg.NotificationPublisher = new ForeachAwaitPublisher();
            });
            return services;
        }
    }
}
