namespace BonsaiTreeShop.Shared.DTOs;

public record RegisterDto(UserDto User, string Password, string ConfirmPassword);