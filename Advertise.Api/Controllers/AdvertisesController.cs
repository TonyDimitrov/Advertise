using Advertise.Api.Data.Models.Enums;
using Advertise.Api.DTO;
using Advertise.Api.Services;
using Advertise.Api.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
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
            this.CallMethod();
            return await this.advertisesService.Get(pageSize, page);
        }

        private void CallMethod()
        {
            var obj = new CreateAdvertiseDTO
            {
                Type = AdvertiseType.None,
                Category = Category.Sale,
                Title = "Lovely 2 bedroom house",
                ContactEmail = "toni@toni.bg",
                ContactPerson = "Toni",
                ContactPhone = "098752645362",
                Property = new CreatePropertyDTO
                {
                    Country = "Bulgaria",
                    Town = "Kyustendil",
                    Description = "Lovely 2 bedroom house - with great garden",
                    Deposit = 300,
                    Price = 30_000
                }
            };

            var toJson = JsonSerializer.Serialize(obj);
        }

        [HttpPost]
        public async Task<ActionResult<PageAdvertisesVm>> Create(CreateAdvertiseDTO advertise)
        {
            var root = Path.Combine(this.env.ContentRootPath, "Images");

            await this.advertisesService.Create(advertise, 1, root);

            return this.RedirectToAction(nameof(this.Get));
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateAdvertiseDTO advertise)
        {
            var root = Path.Combine(this.env.ContentRootPath, "Images");

            var isUpdated = await this.advertisesService.Update(advertise, root);

            return this.Ok(isUpdated);
        }

        [HttpDelete]
        public async Task<ActionResult<PageAdvertisesVm>> Delete(int id)
        {
            var isDeleted = await this.advertisesService.Delete(id);

            return this.Ok(isDeleted);
        }
    }
}
