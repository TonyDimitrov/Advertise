using Advertise.Identity.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Advertise.Identity.Data
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
    }
}
