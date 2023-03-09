namespace BonsaiTreeShop.DataAccess.Repositories.Interfaces;

public interface IRepository<TDto> where TDto : class
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(object id);
    Task<TDto?> AddAsync(TDto dto);
    Task<TDto?> UpdateAsync(TDto dto, object id);
    Task<TDto?> DeleteByIdAsync(object id);
}