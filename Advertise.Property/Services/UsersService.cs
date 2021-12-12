using Advertise.Property.Data.Models;
using Advertise.Property.Data.Repository;
using Advertise.Property.DTO;
using Advertise.Property.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Advertise.Property.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEntityRepository<User> userRepository;

        public UsersService(IEntityRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserViewModel> GetAsync(int id)
        {
            return await this.userRepository.All()
                .Where(u => u.Id == id)
                .Select(u => new UserViewModel
                {
                    Email = u.Email,
                    Name = u.FirstName + (string.IsNullOrEmpty(u.LastName) ? string.Empty : $" {u.LastName}"),
                    Address = u.Address,
                    PhoneNumber = u.PhoneNumber
                }).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await userRepository.All().FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<bool> Login(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegisterDto register)
        {
            var dbUser = new User
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                CreatedOn = DateTime.UtcNow,
                PhoneNumber = register.PhoneNumber,
                Address = register.Address,
                Password = BCryptNet.HashPassword(register.Password)
            };

            await this.userRepository.AddAsync(dbUser);

            return (await this.userRepository.SaveChangesAsync()) != 0;
        }
    }
}
