namespace BonsaiTreeShop.Shared;

public interface IResponseService<TDto>
{
    Task<ServiceResponse<IEnumerable<TDto>>> GetAll();
    Task<ServiceResponse<TDto?>> GetOne(object id);
    Task<ServiceResponse<TDto?>> Add(TDto newDto);
    Task<ServiceResponse<TDto?>> UpdateOne(TDto newDto);
    Task<ServiceResponse<TDto?>> Delete(object id);
}