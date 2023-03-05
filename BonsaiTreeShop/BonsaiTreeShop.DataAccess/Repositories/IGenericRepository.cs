namespace BonsaiTreeShop.DataAccess.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteByIdAsync(object id);
}