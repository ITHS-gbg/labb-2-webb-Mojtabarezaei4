using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests;

public record UpdateProductRequest(ProductDto ProductDto, Guid Id): IHttpRequest;