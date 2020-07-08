using Advertise.Api.DTO;
using Advertise.Api.ViewModels;
using System.Threading.Tasks;

namespace Advertise.Api.Services
{
    public interface IAdvertisesService
    {
        Task<PageAdvertisesVm> Get(int pageSize, int page);

        Task<PageAdvertisesVm> Create(CreateAdvertiseDTO advertise, int userId, string filePath);

        Task<PageAdvertisesVm> Update(CreateAdvertiseDTO advertise);

        Task<PageAdvertisesVm> Delete(CreateAdvertiseDTO advertise);
    }
}
