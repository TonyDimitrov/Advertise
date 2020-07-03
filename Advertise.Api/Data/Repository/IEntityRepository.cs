namespace Advertise.Api.Data.Repository
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEntityRepository<T>
        where T : class
    {
        IQueryable<T> All();

        Task AddAsync(T entity);

        void Edit(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}
