namespace BonsaiTreeShop.Shared.DTOs;

public record UserDto(string FirstName, string LastName, string Email, int PhoneNumber, string Role, string Address);