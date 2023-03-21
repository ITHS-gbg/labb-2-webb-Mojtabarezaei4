using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class UserRepository: IRepository<UserDto>
{
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }


    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userDbContext.Users.Select(u  => new UserDto(
            u.FirstName,
            u.LastName,
            u.Email!,
            u.PhoneNumber,
            u.Address
        )).ToListAsync();
        return users;
    }

    public async Task<UserDto?> GetByIdAsync(object id)
    {
        var user = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == (string)id);
        return user is not null ?
            new UserDto(user.FirstName,user.LastName,user.Email!,user.PhoneNumber,user.Address)
            : null;
    }

    public async Task<UserDto?> AddAsync(UserDto userDto)
    {


        var newUser = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            Address = userDto.Address
        };
        await _userDbContext.Users.AddAsync(newUser);
        return userDto;

    }

    public async Task<UserDto?> UpdateAsync(UserDto userDto, object id)
    {
        var existingUser = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == (string)id);
        if (existingUser is null) return null;
        existingUser.FirstName = userDto.FirstName;
        existingUser.LastName = userDto.LastName;
        existingUser.Email = userDto.Email;
        existingUser.PhoneNumber = userDto.PhoneNumber;
        existingUser.Address = userDto.Address;

        return userDto;
    }

    public async Task<UserDto?> DeleteByIdAsync(object id)
    {
        var existingUser = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == (string)id);
        if (existingUser is null) return null;
        _userDbContext.Users.Remove(existingUser);
        return new UserDto(
            existingUser.FirstName, 
            existingUser.LastName,
            existingUser.Email!,
            existingUser.PhoneNumber,
            existingUser.Address
            );
    }
}