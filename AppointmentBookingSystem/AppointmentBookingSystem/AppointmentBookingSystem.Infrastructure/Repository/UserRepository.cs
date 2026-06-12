using Microsoft.EntityFrameworkCore;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Interface;
using AppointmentBookingSystem.Infrastructure.Data;
using System;

namespace AppointmentBookingSystem.Infrastructure.Repository
{
    public class UserRepository(AppointmentBookingSystemContext _appointmentBookingSystemContext) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetAllUserAsync()
        {
            return await _appointmentBookingSystemContext.User.ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(string password, string usernae)
        {
            var userEntitiy = await _appointmentBookingSystemContext.User.FirstOrDefaultAsync(u => u.Password == password && u.Username == usernae);

            if (userEntitiy == null)
                throw new KeyNotFoundException($"No user  registration found with Id: {usernae}");

            return userEntitiy;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            _appointmentBookingSystemContext.Add(user);
            await _appointmentBookingSystemContext.SaveChangesAsync();
            return user;
        }
    }
}
