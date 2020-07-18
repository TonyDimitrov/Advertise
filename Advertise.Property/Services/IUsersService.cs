using Advertise.Property.DTO;
using Advertise.Property.ViewModels;
using System.Threading.Tasks;

namespace Advertise.Property.Services
{
    public interface IUsersService
    {
        Task<UserViewModel> GetAsync(int id);

        Task<bool> CreateAsync(CreateUserDTO user);
    }
}
