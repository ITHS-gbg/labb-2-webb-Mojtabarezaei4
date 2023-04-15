using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.Orders;

public partial class Orders: ComponentBase
{
    private List<OrderDto> _orders = new();
    protected override async Task OnInitializedAsync()
    {
        var response = await _httpClient.
            GetFromJsonAsync<ServiceResponse<List<OrderDto>>>($"api/orders");

        _orders = response!.Data;

        await base.OnInitializedAsync();
    }
}