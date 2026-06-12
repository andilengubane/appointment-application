using MediatR;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Application.Quiries.UserQueries
{
    public record GetAllUsersQuery : IRequest<IEnumerable<UserEntity>>;
    public class GetAllUsersQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
    {
        public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUserAsync();
        }
    }
}
