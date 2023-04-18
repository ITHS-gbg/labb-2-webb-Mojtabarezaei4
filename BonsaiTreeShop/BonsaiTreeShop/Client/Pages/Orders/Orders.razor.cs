using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.Orders;

public partial class Orders: ComponentBase
{
    private List<OrderDto> _orders = new();

    [Parameter]
    [SupplyParameterFromQuery] 
    public string? UserId { get; set; }

    private string _userName = string.Empty;

    private string _userIdOrEmail = string.Empty;
    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(UserId))
        {
            var orderResponse = await _httpClient.
                GetFromJsonAsync<ServiceResponse<List<OrderDto>>>($"api/orders");
            _orders = orderResponse!.Data;

            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            _userIdOrEmail = authenticationState.User.Identity!.Name!;
        }
        else
        {
            var response = await _httpClient.
            GetFromJsonAsync<ServiceResponse<List<OrderDto>>>($"api/orders?UserId={UserId}");
            _orders = response!.Data;

            _userIdOrEmail = UserId;
        }

        var userResponse = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>($"api/users/{_userIdOrEmail}");
        _userName = userResponse!.Data.FirstName;

        await base.OnInitializedAsync();
    }
}