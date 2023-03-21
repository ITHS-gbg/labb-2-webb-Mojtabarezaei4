using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly DataContext _dataContext;
    private readonly UserDbContext _userContext;
    public IRepository<ProductDto> ProductRepository { get; private set; }
    public IRepository<UserDto> UserRepository { get; private set; }

    public UnitOfWork(DataContext dataContext, UserDbContext userContext)
    {
        _dataContext = dataContext;
        _userContext = userContext;

        ProductRepository = new ProductRepository(_dataContext);
        UserRepository = new UserRepository(_userContext);
    }

    public async Task CompleteAsync()
    {
        await _dataContext.SaveChangesAsync();
        await _userContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dataContext.Dispose();
    }
}