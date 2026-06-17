using AppointmentBookingSystem.Domain.Entities;

namespace AppointmentBookingSystem.Domain.Interface
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<AppointmentEntity>> GetAllAppointmentsAsync();
        Task<AppointmentEntity> GetAppointmentByIdAsync(Guid id);
        Task<AppointmentEntity> AddAppointmentAsync(AppointmentEntity appointmentEntity);
        Task<AppointmentEntity> UpdateAppointmentAsync(Guid Id, AppointmentEntity appointmentEntity);
    }
}
