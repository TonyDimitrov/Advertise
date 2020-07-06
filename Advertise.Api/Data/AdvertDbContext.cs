namespace Advertise.Api.Data
{
    using Advertise.Api.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class AdvertDbContext : DbContext
    {
        public AdvertDbContext(DbContextOptions<AdvertDbContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Advertise> Advertises { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Raffle> Raffles { get; set; }
    }
}
