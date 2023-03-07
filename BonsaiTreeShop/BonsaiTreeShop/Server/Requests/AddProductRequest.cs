using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests;

public record AddProductRequest(ProductDto ProductDto) : IHttpRequest;