using Advertise.Api.DTO;
using Advertise.Property.Data.Models.Enums;
using Advertise.Property.DTO;
using Advertise.Property.Services;
using Advertise.Property.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Advertise.Property.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertisesController : ControllerBase
    {
        private readonly IAdvertisesService advertisesService;
        private readonly IFilesService filesService;
        private readonly IWebHostEnvironment env;

        public AdvertisesController(IAdvertisesService advertisesService, IFilesService filesService, IWebHostEnvironment env)
        {
            this.advertisesService = advertisesService;
            this.filesService = filesService;
            this.env = env;
        }

        [HttpGet("{pageSize?}/{page?}")]
        public async Task<ActionResult<PageAdvertisesVm>> Get(int? pageSize, int? page)
        {
            var result = await this.advertisesService.Get(pageSize, page);

            return this.Ok(result);
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult<DetailsPropertyDTO>> Details(int id)
        {
            var result = await this.advertisesService.GetById(id);

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PageAdvertisesVm>> Create([FromForm] CreateAdvertiseFlatDto advertise)
        {
            var root = Path.Combine(this.env.ContentRootPath, "Images");

            await this.advertisesService.Create(new CreateAdvertiseDTO(advertise), 1, root);

            return this.Ok();
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

        [HttpGet]
        [Route("GetImage/{image}")]
        public async Task<ActionResult> GetImage(string image)
        {
            if (image == null)
            {
                return null;
            }
            var root = Path.Combine(this.env.ContentRootPath, "Images");

            var stream = filesService.GetFile(root, image);

            var fileExtension = Path.GetExtension(image).TrimStart('.');

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return new FileStreamResult(stream, $"application/{fileExtension}");
        }

        private string CallMethod()
        {
            var advertise = new CreateAdvertiseDTO
            {
                Type = AdvertiseType.Regular,
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
                    Price = 60_000,
                    Images = new List<IFormFile>()
                }
            };

            return JsonSerializer.Serialize(advertise);
        }
    }
}
