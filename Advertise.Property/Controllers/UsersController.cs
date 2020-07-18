using Advertise.Property.DTO;
using Advertise.Property.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace Advertise.Property.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult> Get([FromQuery]int? id)
        {
            var user = new CreateUserDTO
            {
                Email = "toni@toni.com",
                FirstName = "Toni",
                LastName = "Dimitrov",
                Address = "Rila 56A",
                PhoneNumber = "09876543"
            };

            var toJson = JsonSerializer.Serialize(user);

            return await Task.FromResult(this.Ok(toJson));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserDTO user)
        {
          return this.Ok(await this.usersService.CreateAsync(user));
        }
    }
}
