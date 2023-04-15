using System.Net.Http.Json;
using BonsaiTreeShop.Shared;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace BonsaiTreeShop.Client.Pages.Products
{
    public partial class SpecificProduct : ComponentBase
    {
        private ProductDto Product;

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await _httpClient.
                CreateClient("public").GetFromJsonAsync<ServiceResponse<ProductDto?>>($"api/products/{Id}");
            
            Product = response.Data;

            await base.OnInitializedAsync();
        }
    }
}
