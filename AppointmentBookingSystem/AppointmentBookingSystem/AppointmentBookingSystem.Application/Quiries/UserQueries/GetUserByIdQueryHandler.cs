using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Application.Quiries.UserQueries
{
    public record GetUserByIdQuery(string password, string username) : IRequest<UserEntity>;

    public class GetUserByIdQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(request.password, request.username);
        }
    }
}