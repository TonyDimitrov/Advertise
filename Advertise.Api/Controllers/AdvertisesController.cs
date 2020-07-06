using Advertise.Api.DTO;
using Advertise.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Advertise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertisesController : ControllerBase
    {
        [HttpGet("{pageSize?}/{page?}")]
        public async Task<ActionResult<PageAdvertisesVm>> Get(int? pageSize, int? page)
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<PageAdvertisesVm>> Create(CreateAdvertiseDTO advertise)
        {
            return null;
        }

        [HttpPut]
        public async Task<ActionResult<PageAdvertisesVm>> Update(CreateAdvertiseDTO advertise)
        {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<PageAdvertisesVm>> Delete(CreateAdvertiseDTO advertise)
        {
            return null;
        }
    }
}  
