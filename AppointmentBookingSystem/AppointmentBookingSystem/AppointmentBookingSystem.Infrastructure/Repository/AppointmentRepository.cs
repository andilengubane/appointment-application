using Microsoft.EntityFrameworkCore;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;
using AppointmentBookingSystem.Infrastructure.Data;

namespace AppointmentBookingSystem.Infrastructure.Repository
{
    public class AppointmentRepository(AppointmentBookingSystemContext _appointmentBookingSystemContext) :  IAppointmentRepository
    {
        public async Task<IEnumerable<AppointmentEntity>> GetAllAppointmentsAsync()
        {
            return await _appointmentBookingSystemContext.Appointment.ToListAsync();
        }

        public async Task<AppointmentEntity> GetAppointmentByIdAsync(Guid id)
        {
            var appointmentEntity = await _appointmentBookingSystemContext.Appointment.FirstOrDefaultAsync(u => u.Id == id);

            if (appointmentEntity == null)
            { 
                throw new KeyNotFoundException($"No appointment  registration found with Id: {id}");
            }
            return appointmentEntity;
        }

        public async Task<AppointmentEntity> AddAppointmentAsync(AppointmentEntity appointmentEntity)
        {
            _appointmentBookingSystemContext.Add(appointmentEntity);
            await _appointmentBookingSystemContext.SaveChangesAsync();
            return appointmentEntity;
        }

        public async Task<AppointmentEntity> UpdateAppointmentAsync(Guid Id, AppointmentEntity appointmentEntity)
        {
            var appointmentData = await _appointmentBookingSystemContext.Appointment.SingleOrDefaultAsync(u => u.Id == Id);
            if (appointmentData is not null)
            {
                appointmentData.Id = Id;
                appointmentData.Title = appointmentEntity.Title;
                appointmentData.Description = appointmentEntity.Description;
                appointmentData.RequestedBy = appointmentEntity.RequestedBy;
                appointmentData.UpdateBy = appointmentEntity.UpdateBy;
                appointmentData.CreatedDate = DateTime.UtcNow;
                appointmentData.UpdatedDate = DateTime.UtcNow;
                appointmentData.IsActive = appointmentEntity.IsActive;

                _appointmentBookingSystemContext.Add(appointmentData);
                await _appointmentBookingSystemContext.SaveChangesAsync();

                return appointmentData;
            }
            return appointmentEntity;
        }
    }
}
