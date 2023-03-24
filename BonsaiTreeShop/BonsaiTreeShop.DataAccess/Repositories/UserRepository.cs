using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.DataAccess.Services;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class UserRepository: IRepository<UserDto>
{
    private readonly DataContext _userDbContext;

    public UserRepository(DataContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userDbContext.Users.ToListAsync();
        var userDtos = users.Select(Converter.ConvertToUserDto);

        return userDtos;
    }

    public async Task<UserDto?> GetByIdAsync(object id)
    {
        var user = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Id == (string)id);
        return user is not null ?
            Converter.ConvertToUserDto(user)
            : null;
    }

    public async Task<UserDto?> AddAsync(UserDto userDto)
    {
        var newUser = Converter.ConvertToUser(userDto);
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

        return Converter.ConvertToUserDto(existingUser);
    }
}