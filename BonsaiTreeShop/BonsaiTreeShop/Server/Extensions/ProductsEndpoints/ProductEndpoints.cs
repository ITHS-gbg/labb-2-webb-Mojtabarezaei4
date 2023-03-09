using BonsaiTreeShop.Server.Requests.Deletes;
using BonsaiTreeShop.Server.Requests.Gets;
using BonsaiTreeShop.Server.Requests.Posts;
using BonsaiTreeShop.Server.Requests.Puts;

namespace BonsaiTreeShop.Server.Extensions.ProductsEndpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllProductRequest>("/products");
        app.MediateGet<GetProductByIdRequest>("/products/{id}");

        app.MediatePost<PostProductRequest>("/addProduct");

        app.MediatePut<UpdateProductRequest>("/products/{id}");

        app.MediateDelete<DeleteProductRequest>("/products/{id}");

    }
}