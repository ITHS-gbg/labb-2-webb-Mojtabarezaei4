using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        return await _userDbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(object id)
    {
        return await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == (string)id);
    }

    public async Task<User?> AddAsync(User user)
    {
        await _userDbContext.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> UpdateAsync(User user)
    {
        var existingUser = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        if (existingUser is null) return null;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.Address = user.Address;

        return existingUser;
    }

    public async Task? DeleteByIdAsync(object id)
    {
        var existingUser = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == (string)id);
        if (existingUser is null) return;
        _userDbContext.Users.Remove(existingUser);
    }
}