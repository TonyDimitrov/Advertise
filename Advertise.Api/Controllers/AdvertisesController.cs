using Advertise.Api.DTO;
using Advertise.Api.Services;
using Advertise.Api.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Advertise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertisesController : ControllerBase
    {
        private readonly IAdvertisesService advertisesService;
        private readonly IWebHostEnvironment env;

        public AdvertisesController(IAdvertisesService advertisesService, IWebHostEnvironment env)
        {
            this.advertisesService = advertisesService;
            this.env = env;
        }

        [HttpGet("{pageSize?}/{page?}")]
        public async Task<ActionResult<PageAdvertisesVm>> Get(int? pageSize, int? page)
        {
            return await this.advertisesService.Get(pageSize, page);
        }

        [HttpPost]
        public async Task<ActionResult<PageAdvertisesVm>> Create(CreateAdvertiseDTO advertise)
        {
            var root = Path.Combine(this.env.ContentRootPath, "Images");

            await this.advertisesService.Create(advertise, 1, root);

            return this.RedirectToAction(nameof(this.Get));
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
