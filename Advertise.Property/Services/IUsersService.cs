using Advertise.Property.Data.Models;
using Advertise.Property.DTO;
using Advertise.Property.ViewModels;
using System.Threading.Tasks;

namespace Advertise.Property.Services
{
    public interface IUsersService
    {
        Task<UserViewModel> GetAsync(int id);

        Task<User> GetByEmailAsync(string email);

        Task<bool> RegisterAsync(RegisterDto user);

        Task<bool> Login(LoginDto login);

        Task<bool> Logout();
    }
}
