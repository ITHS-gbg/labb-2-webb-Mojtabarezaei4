using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<ProductDto> ProductRepository { get; }
    IRepository<UserDto> UserRepository { get; }

    Task CompleteAsync();
}