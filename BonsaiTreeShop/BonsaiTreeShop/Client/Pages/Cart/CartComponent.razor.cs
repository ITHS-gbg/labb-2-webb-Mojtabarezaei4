using System.Net.Http.Json;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace BonsaiTreeShop.Client.Pages.Cart
{
    public partial class CartComponent : ComponentBase
    {
        private List<OrderDetailsDto> _cartItems = new();
        private int _totalItemsInCart = 0;
        private decimal _totalPrice = 0;
        private List<ProductDto> _productItems = new();
        private UserDto _user = new();
        private string _shipAddress = string.Empty;
        private string _userIdOrEmail = string.Empty;
        
        protected override async Task OnParametersSetAsync()
        {
            _addToCartService.AddToCart += StateHasChanged;
            _cartItems = _addToCartService.CartItems;
            _totalItemsInCart = _cartItems.Count;

            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            _userIdOrEmail = authenticationState!.User.Identity!.Name!;

            var userResponse = await _httpClient.GetFromJsonAsync<ServiceResponse<UserDto>>($"api/users/{_userIdOrEmail}");
            _user = userResponse!.Data;

            var cartFromLocalStorage = await _localStorageService.GetItemAsync<IEnumerable<OrderDetailsDto>>("cart");
            if (cartFromLocalStorage is not null)
            {
                var fromLocalStorage = cartFromLocalStorage.ToList();
                _cartItems = fromLocalStorage.ToList();
            }

            if (_cartItems.Any())
            {
                _totalItemsInCart = _cartItems.Count();
                foreach (var item in _cartItems)
                {
                    var product = await AddToProductListAsync(item.ProductId);
                    _totalPrice += item.Quantity * product.Data.Price;
                }
            }
        }

        private async Task<ServiceResponse<ProductDto>> AddToProductListAsync(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<ProductDto>>($"api/products/{id}");
            if (!response!.Success) return response;
            _productItems.Add(response.Data);
            return response;
        }

        private async Task Increase(ProductDto productDto)
        {
            await _adjustCartService.IncreaseQuantityAsync(productDto);
            _totalPrice += productDto.Price;
            _cartItems.First(ci => ci.ProductId == productDto.Id).Quantity++;
        }

        private async Task Decrease(ProductDto productDto)
        {
            if (_cartItems.First(ci => ci.ProductId == productDto.Id).Quantity == 1)
            {
                return;
                await Delete(productDto);
            }
            if (_cartItems.First(ci => ci.ProductId == productDto.Id).Quantity > 1)
            {
                await _adjustCartService.DecreaseQuantityAsync(productDto);
                _cartItems.First(ci => ci.ProductId == productDto.Id).Quantity--;
                _totalPrice -= productDto.Price;
            }
            
        }
        private async Task Delete(ProductDto productDto)
        {
            await _adjustCartService.DecreaseQuantityAsync(productDto);
            var orderDetailsDto = _cartItems.First(ci => ci.ProductId == productDto.Id);
            _cartItems.Remove(orderDetailsDto);
            _totalPrice -= productDto.Price;
            _totalItemsInCart--;
        }

        private async Task PlaceTheOrder()
        {
            if (string.IsNullOrEmpty(_shipAddress)) return;
            if (_cartItems.Any())
            {
                var order = new OrderDto()
                {
                    OrderDetails = _cartItems,
                    ShipAddress = _shipAddress
                };
                try
                {
                    var response = await _httpClient
                        .PostAsJsonAsync("api/addOrder", order);

                    _cartItems.Clear();
                    _totalItemsInCart = 0;
                    _totalPrice = 0;
                    _cartItems.Clear();
                    
                    var orderId = await response.Content.ReadFromJsonAsync<ServiceResponse<OrderDto>>();
                    Console.WriteLine(orderId.Data);
                    await _localStorageService.ClearAsync();
                    _navigationManager.NavigateTo($"orders/{orderId!.Data.Id}");

                }
                catch (Exception e)
                {
                    _navigationManager.NavigateTo("failed");
                }
            }
        }
        public void Dispose()
        {
            _addToCartService.AddToCart -= StateHasChanged;
        }
    }
}
