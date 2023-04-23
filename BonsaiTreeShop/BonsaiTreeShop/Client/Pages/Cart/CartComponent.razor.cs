using System.Net.Http.Json;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace BonsaiTreeShop.Client.Pages.Cart
{
    public partial class CartComponent : ComponentBase
    {
        private List<CartItem> _cartItems = new();
        private UserDto _user = new();
        private string _shipAddress = string.Empty;
        private string _userIdOrEmail = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            _cartService.CartOnChange += StateHasChanged;
            _cartItems = await _cartService.GetCartItemsAsync();

            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            _userIdOrEmail = authenticationState!.User.Identity!.Name!;

            var userResponse = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>($"api/users/{_userIdOrEmail}");
            _user = userResponse!.Data;

        }
        private async Task PlaceTheOrder()
        {
            if (string.IsNullOrEmpty(_shipAddress)) return;

            if (!_cartItems.Any()) return;

            var order = new OrderDto()
            {
                OrderDetails = _cartItems.Select(ci => new OrderDetailsDto()
                {
                    Quantity = ci.Quantity,
                    ProductId = ci.ProductId
                }),
                ShipAddress = _shipAddress
            };
            try
            {
                var response = await _httpClient
                    .PostAsJsonAsync("api/addOrder", order);

                _cartItems.Clear();

                var orderId = await response.Content.ReadFromJsonAsync<ServiceResponse<OrderDto>>();

                await _localStorageService.ClearAsync();
                _navigationManager.NavigateTo($"orders/{orderId!.Data.Id}");

            }
            catch (Exception e)
            {
                _navigationManager.NavigateTo("failed");
            }

        }
        public void Dispose()
        {
            _cartService.CartOnChange -= StateHasChanged;
        }
    }
}
