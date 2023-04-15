using BonsaiTreeShop.Shared.DTOs;
using BonsaiTreeShop.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace BonsaiTreeShop.Client.Pages.Products.ProductManagement;

public partial class EditProduct: ComponentBase
{
    private ProductDto Product;

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ServiceResponse<ProductDto?>>($"api/products/{Id}");

        Product = response.Data;

        await base.OnInitializedAsync();
    }

    private async Task UpdateProductAsync(EditContext formContext)
    {
        var formIsValid = formContext.Validate();
        if (formIsValid is false) return;

        var response = await _httpClient.PutAsJsonAsync($"updateProduct/{Product.Id}", Product);

        if (response.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/productManagement");
        }
    }

    private async Task DeleteProductAsync(EditContext formContext)
    {

        var formIsValid = formContext.Validate();
        if (formIsValid is false) return;

        var response = await _httpClient.DeleteAsync($"deleteProduct/{Product.Id}");

        if (response.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/productManagement");
        }
    }
}