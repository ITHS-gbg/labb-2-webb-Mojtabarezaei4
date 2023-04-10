using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.Products.ProductManagement;

public partial class AddNewProduct: ComponentBase
{
    private ProductDto NewProduct = new();

    private async Task AddProduct()
    {
        var resonse = await _httpClient.PostAsJsonAsync("addProduct", NewProduct);

        _navigationManager.NavigateTo("/productManagement");
    }
}