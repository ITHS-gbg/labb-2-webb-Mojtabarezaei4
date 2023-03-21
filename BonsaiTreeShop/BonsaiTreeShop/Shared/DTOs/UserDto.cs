namespace BonsaiTreeShop.Shared.DTOs;

public record UserDto(string FirstName, string LastName, string Email, string? PhoneNumber, string? Address);