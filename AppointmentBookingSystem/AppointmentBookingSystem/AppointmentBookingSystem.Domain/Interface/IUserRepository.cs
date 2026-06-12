using AppointmentBookingSystem.Domain.Entities;

namespace AppointmentBookingSystem.Domain.Interface
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity userEntitiy);
        Task<IEnumerable<UserEntity>> GetAllUserAsync();
        Task<UserEntity> GetUserByIdAsync(string password, string username);
    }
}
