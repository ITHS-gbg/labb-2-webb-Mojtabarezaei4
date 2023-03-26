using System.Net.Http.Json;
using Blazored.SessionStorage;
using BonsaiTreeShop.Client.Shared;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace BonsaiTreeShop.Client.Pages.Cart
{
    public partial class CartComponent : ComponentBase
    {
        private Dictionary<ProductDto, int> CartItems = new();
        private int TotalItemsInCart = 0;
        private decimal TotalPrice = 0;

        private UserDto User = new("", "", "", "", "");
        private OrderDto _orderDto;
        private List<OrderDetailsDto> _orderDetailsDto;
        private string _shipAddress = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            _addToCartService.AddToCart += StateHasChanged;
            CartItems = _addToCartService.Products;
            TotalItemsInCart = CartItems.Count;

            //var profile = await _sessionStorageService.GetItemAsStringAsync("profile");
            //string sub;
            //foreach (var item in profile)
            //{
            //    if (item.Equals("sub"))
            //    {
            //        sub = item;
            //    }
            //}

            //var response = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>("users/{sub}");


            if (CartItems.Any())
            {
                TotalItemsInCart = CartItems.Sum(p => p.Value);
                TotalPrice = CartItems.Sum(p => p.Key.Price * p.Value);
            }
            await base.OnInitializedAsync();
        }

        public void Dispose()
        {
            _addToCartService.AddToCart -= StateHasChanged;
        }
        private async Task PlaceTheOrder()
        {

            if (CartItems.Any())
            {
                _orderDetailsDto = CartItems.Select( ci => new OrderDetailsDto(ci.Key.Id, ci.Value)).ToList();
            }

            if (_orderDetailsDto.Any())
            {
                var order = new OrderDtoShort()
                {
                    OrderDetails = _orderDetailsDto,
                    ShipAddress = _shipAddress
                };
                try
                {
                    var response = await _httpClient
                        .PostAsJsonAsync("addOrder", order);
                    _navigationManager.NavigateTo("receipt");

                }
                catch (Exception e)
                {
                    _navigationManager.NavigateTo("failed");
                }

            }

        }
        private class OrderDtoShort
        {
            public string ShipAddress { get; set; }
            public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
        }
    }

    
}
