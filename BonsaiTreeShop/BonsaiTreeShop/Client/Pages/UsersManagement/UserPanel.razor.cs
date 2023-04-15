using BonsaiTreeShop.Shared.DTOs;
using BonsaiTreeShop.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.UsersManagement;

public partial class UserPanel : ComponentBase
{
    public string SearchInput { get; set; } = string.Empty;
    private List<UserDto> _users = new();
    public List<UserDto> FilteredUsers => _users.Where(
        p =>
            p.FirstName.ToLower().Contains(SearchInput.ToLower()) ||
             p.LastName.ToLower().Contains(SearchInput.ToLower()) ||
             p.Email.ToLower().Contains(SearchInput.ToLower()))
        .ToList();

    protected override async Task OnInitializedAsync()
    {
        var response = await _httpClient.
            GetFromJsonAsync<ServiceResponse<List<UserDto>>>("api/users");

        _users = response!.Data;

        await base.OnInitializedAsync();
    }
}