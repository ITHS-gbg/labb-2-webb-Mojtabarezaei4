using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests.Puts;

public record UpdateProductRequest(ProductDto ProductDto, Guid Id, HttpContext HttpContext) : IHttpRequest;