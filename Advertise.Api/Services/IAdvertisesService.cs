using Advertise.Api.DTO;
using Advertise.Api.ViewModels;
using System.Threading.Tasks;

namespace Advertise.Api.Services
{
    public interface IAdvertisesService
    {
        Task<Data.Models.Advertise> GetById(int id);

        Task<PageAdvertisesVm> Get(int? pageSize, int? page);

        Task Create(CreateAdvertiseDTO advertise, int userId, string filePath);

        Task<bool> Update(UpdateAdvertiseDTO advertise, string filePath);

        Task<bool> Delete(int id);
    }
}
