using Advertise.Property.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Advertise.Property.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaffleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PageAdvertisesVm>> Get()
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<PageAdvertisesVm>> Register()
        {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<PageAdvertisesVm>> Delete()
        {
            return null;
        }
    }
}
