namespace Advertise.Api.Data
{
    using Advertise.Api.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class AdvertDbContext : DbContext
    {
        public AdvertDbContext(DbContextOptions<AdvertDbContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Raffle> Raffles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
