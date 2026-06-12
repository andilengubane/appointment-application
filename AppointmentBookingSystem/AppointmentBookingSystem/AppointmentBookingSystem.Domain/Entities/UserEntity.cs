namespace AppointmentBookingSystem.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string  Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
