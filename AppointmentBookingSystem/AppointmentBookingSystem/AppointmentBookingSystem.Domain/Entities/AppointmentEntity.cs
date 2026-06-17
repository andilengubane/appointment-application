namespace AppointmentBookingSystem.Domain.Entities
{
    public class AppointmentEntity
    {
        public  Guid Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Boolean IsActive { get; set; } = true;
        public string RequestedBy { get; set; } = string.Empty;
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
