namespace Advertise.Property.Data.Repository
{
    using Advertise.Property.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class EntityRepository<T> : IEntityRepository<T>
        where T : BaseModel
    {
        public EntityRepository(AdvertDbContext dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.Entities = dbContext.Set<T>();
        }

        public AdvertDbContext DbContext { get; set; }

        public DbSet<T> Entities { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.Entities;
        }

        public virtual async Task AddAsync(T entity)
        {
            await this.Entities.AddAsync(entity);
        }

        public virtual void Edit(T entity)
        {
            this.Entities.Update(entity);
        }

        public virtual void HardDelete(T entity)
        {
            this.Entities.Remove(entity);
        }

        public async virtual Task SoftDelete(T entity)
        {
            var model = this.Entities.Find(entity);

            model.DeletedOn = DateTime.UtcNow;
            model.IsDeleted = true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.DbContext.SaveChangesAsync();
        }
    }
}
