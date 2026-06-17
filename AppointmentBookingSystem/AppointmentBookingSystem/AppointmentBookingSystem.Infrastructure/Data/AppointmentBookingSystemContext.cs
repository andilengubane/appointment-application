using AppointmentBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBookingSystem.Infrastructure.Data
{
    public class AppointmentBookingSystemContext : DbContext
    {
        public AppointmentBookingSystemContext() { }
        public AppointmentBookingSystemContext(DbContextOptions<AppointmentBookingSystemContext> option)
               : base(option)
        {
        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<AppointmentEntity> Appointment { get; set; }
    }
}
