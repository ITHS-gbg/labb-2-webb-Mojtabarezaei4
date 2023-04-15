namespace BonsaiTreeShop.Shared.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Address { get; init; }
}