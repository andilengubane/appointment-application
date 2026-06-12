using AppointmentBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
