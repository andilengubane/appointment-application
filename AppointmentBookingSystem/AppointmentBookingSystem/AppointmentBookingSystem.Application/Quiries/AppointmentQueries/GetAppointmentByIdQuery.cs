using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Application.Quiries.AppointmentQueries
{
    public record GetAppointmentByIdQuery(Guid id) : IRequest<AppointmentEntity>;

    public class GetAppointmentByIdQueryHandler(IAppointmentRepository _appointmentRepository) : IRequestHandler<GetAppointmentByIdQuery, AppointmentEntity>
    {
        public async Task<AppointmentEntity> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(request.id);
        }
    }
}
