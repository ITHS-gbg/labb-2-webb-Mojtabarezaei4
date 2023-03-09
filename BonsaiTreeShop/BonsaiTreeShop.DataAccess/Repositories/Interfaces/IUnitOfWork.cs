using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<ProductDto> ProductRepository { get; }

    Task CompleteAsync();
}