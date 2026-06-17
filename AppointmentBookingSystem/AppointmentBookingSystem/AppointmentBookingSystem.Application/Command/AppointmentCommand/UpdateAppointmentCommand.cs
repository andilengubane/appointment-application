using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Application.Command.AppointmentCommand
{
    public record UpdateAppointmentCommand(Guid id, AppointmentEntity appointmentEntity) : IRequest<AppointmentEntity>;
    public class UpdateSalesItemsCommandHandler(IAppointmentRepository _appointmentRepository) : IRequestHandler<UpdateAppointmentCommand, AppointmentEntity>
    {
        public async Task<AppointmentEntity> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.UpdateAppointmentAsync(request.id, request.appointmentEntity);
        }
    }
}
