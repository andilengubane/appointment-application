using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingSystem.Domain.Options
{
    public class ConnectioStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string PostgressConnectionString { get; set; } = null!;
    }
}
