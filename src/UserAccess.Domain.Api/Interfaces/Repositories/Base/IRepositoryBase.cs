namespace UserAccess.Api.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T, TKey>
    {
        Task<List<T>> ListAllAsync();
        Task<T?> GetByIdAsync(TKey id);
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(TKey id);
    }
}


