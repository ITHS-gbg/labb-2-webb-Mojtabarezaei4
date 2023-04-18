using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<ProductDto> ProductRepository { get; }
    IRepository<UserDto> UserRepository { get; }
    IRepository<OrderDto> OrderRepository { get;}

    Task CompleteAsync();
}