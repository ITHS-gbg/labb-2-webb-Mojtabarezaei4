using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests.Posts;

public record PostProductRequest(ProductDto ProductDto) : IHttpRequest;