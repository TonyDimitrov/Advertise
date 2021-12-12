using Advertise.Property.DTO;
using Advertise.Property.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Advertise.Property.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly IJwtService jwtService;

        public UsersController(IUsersService usersService, IJwtService jwtService)
        {
            this.usersService = usersService;
            this.jwtService = jwtService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromQuery] int? id)
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            return this.Ok(await this.usersService.RegisterAsync(register));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await usersService.GetByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest();
            }

            if (!BCryptNet.Verify( login.Password, user.Password))
            {
                return BadRequest();
            }

            var jwt = jwtService.Genereta(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return this.Ok(new { jwt });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return this.Ok();
        }
    }
}
