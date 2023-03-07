using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly DataContext _dataContext;
    public IRepository<ProductDto> ProductRepository { get; private set; }

    public UnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;

        ProductRepository = new ProductRepository(_dataContext);
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