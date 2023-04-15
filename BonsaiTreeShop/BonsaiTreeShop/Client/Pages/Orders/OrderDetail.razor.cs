using BonsaiTreeShop.Shared.DTOs;
using BonsaiTreeShop.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.Orders;

public partial class OrderDetail : ComponentBase
{
    private OrderDto Order = new();
    private Dictionary<ProductDto, int> Products = new();
    private string User = String.Empty;
    private decimal totalPrice = 0;

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var orderResponse = await _httpClient.
            GetFromJsonAsync<ServiceResponse<OrderDto?>>($"api/orders/{Id}");

        Order = orderResponse!.Data!;

        var orderUser = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>($"/api/users/{Order.UserId}");
        User = orderUser!.Data.FirstName + " " + orderUser.Data.LastName;

        foreach (var orderDetail in Order.OrderDetails)
        {
            var product = await _httpClient.
                GetFromJsonAsync<ServiceResponse<ProductDto?>>($"api/products/{orderDetail.ProductId}");
            if (product is not null && product.Success)
            {
                Products.Add(product!.Data!, orderDetail.Quantity);
                totalPrice += product.Data!.Price * orderDetail.Quantity;
            }
        }
        await base.OnInitializedAsync();
    }

}