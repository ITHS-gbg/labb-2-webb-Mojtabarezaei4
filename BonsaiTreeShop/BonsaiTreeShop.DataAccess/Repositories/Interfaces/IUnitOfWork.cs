using BonsaiTreeShop.DataAccess.Model;

namespace BonsaiTreeShop.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<Product> ProductRepository { get; }

    Task CompleteAsync();
}