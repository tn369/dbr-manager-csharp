namespace Domain.Repositories
{
    public interface IRepository<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(TId id);
    }
}
