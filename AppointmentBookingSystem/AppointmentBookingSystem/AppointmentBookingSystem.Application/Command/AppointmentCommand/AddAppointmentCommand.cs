using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Application.Command.AppointmentCommand
{
    public record AddAppointmentCommand(AppointmentEntity appointmentEntity) : IRequest<AppointmentEntity>;

    public class AddAppointmentHandler(IAppointmentRepository _appointmentRepository) : IRequestHandler<AddAppointmentCommand, AppointmentEntity>
    {
        public async Task<AppointmentEntity> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appoiontmentData = await _appointmentRepository.AddAppointmentAsync(request.appointmentEntity);
            return appoiontmentData;
        }
    }
}
