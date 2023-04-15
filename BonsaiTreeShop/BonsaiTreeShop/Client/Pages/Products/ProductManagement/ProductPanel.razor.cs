using BonsaiTreeShop.Shared.DTOs;
using BonsaiTreeShop.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.Products.ProductManagement;

public partial class ProductPanel: ComponentBase
{
    public string SearchInput { get; set; } = string.Empty;
    private List<ProductDto> _products = new();
    public List<ProductDto> FilteredProducts => _products.Where(
        p => p.Name.ToLower().Contains(SearchInput.ToLower())).ToList();

    protected override async Task OnInitializedAsync()
    {
        var response = await _httpClient.
            CreateClient("public").
            GetFromJsonAsync<ServiceResponse<List<ProductDto>>>("api/products");

        _products = response!.Data;

        await base.OnInitializedAsync();
    }
}