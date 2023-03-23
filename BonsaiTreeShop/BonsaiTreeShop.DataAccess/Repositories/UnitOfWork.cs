using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly DataContext _dataContext;
    public IRepository<ProductDto> ProductRepository { get; private set; }
    public IRepository<UserDto> UserRepository { get; private set; }
    public IRepository<OrderDto> OrderRepository { get; private set; }
    public UnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;

        ProductRepository = new ProductRepository(_dataContext);
        UserRepository = new UserRepository(_dataContext);
        OrderRepository = new OrderRepository(_dataContext);
    }

    public async Task CompleteAsync()
    {
        await _dataContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dataContext.Dispose();
    }
}