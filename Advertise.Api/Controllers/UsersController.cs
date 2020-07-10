using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Advertise.Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult> Get(int id)
        {

        }

        [HttpPost]
        public Task<ActionResult> Create(int id)
        {

        }

    }
}
