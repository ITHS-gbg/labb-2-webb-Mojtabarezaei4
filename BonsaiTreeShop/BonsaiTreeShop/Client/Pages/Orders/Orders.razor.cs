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
    public Guid UserId { get; set; }

    private string _userName = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var response = await _httpClient.
            GetFromJsonAsync<ServiceResponse<List<OrderDto>>>($"api/orders?UserId={UserId}");
        _orders = response!.Data;

        var userResponse = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>($"api/users/{UserId}");
        _userName = userResponse!.Data.FirstName;

        await base.OnInitializedAsync();
    }
}