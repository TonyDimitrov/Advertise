namespace Advertise.Property.Data.Repository
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEntityRepository<T>
        where T : class
    {
        IQueryable<T> All();

        Task AddAsync(T entity);

        void Edit(T entity);

        void HardDelete(T entity);

        Task SoftDelete(T entity);

        Task<int> SaveChangesAsync();
    }
}
