using Advertise.Property.Data.Models;
using Advertise.Property.Data.Repository;
using Advertise.Property.DTO;
using Advertise.Property.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> CreateAsync(CreateUserDTO user)
        {
            var dbUser = new User
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedOn = DateTime.UtcNow,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            };

            await this.userRepository.AddAsync(dbUser);

            return (await this.userRepository.SaveChangesAsync()) != 0;
        }
    }
}
