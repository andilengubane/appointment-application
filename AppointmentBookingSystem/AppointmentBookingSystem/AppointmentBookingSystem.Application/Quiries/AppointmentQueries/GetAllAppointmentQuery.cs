using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Application.Quiries.AppointmentQueries
{
    public record GetAllAppointmentQuery: IRequest<IEnumerable<AppointmentEntity>>;

    public class GetAllAppointmentQueryHandler(IAppointmentRepository _appointmentRepository) : IRequestHandler<GetAllAppointmentQuery, IEnumerable<AppointmentEntity>>
    {
        public async Task<IEnumerable<AppointmentEntity>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }
    }
}
