using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.Server.Requests.Posts.ProductPost;

public record PostProductRequest(ProductDto ProductDto, HttpContext HttpContext) : IHttpRequest;