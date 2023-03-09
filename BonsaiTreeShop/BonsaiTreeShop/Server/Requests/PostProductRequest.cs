using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests;

public record PostProductRequest(ProductDto ProductDto) : IHttpRequest;