using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;


namespace AppointmentBookingSystem.Application.Command.UserCommand
{
    public record AddUserCommand(UserEntity userEntitiy) : IRequest<UserEntity>;
    public class AddUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<AddUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var purchaseAirtimeToken = await _userRepository.AddUserAsync(request.userEntitiy);
            return purchaseAirtimeToken;
        }
    }
}
