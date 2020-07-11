using Advertise.Api.DTO;
using Advertise.Api.ViewModels;
using System.Threading.Tasks;

namespace Advertise.Api.Services
{
    public interface IUsersService
    {
        Task<UserViewModel> GetAsync(int id);

        Task<bool> CreateAsync(CreateUserDTO user);
    }
}
