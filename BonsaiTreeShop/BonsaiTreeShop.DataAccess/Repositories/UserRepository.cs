using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class UserRepository: IRepository<User>
{
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }


    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(object id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(object id)
    {
        throw new NotImplementedException();
    }
}