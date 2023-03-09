using BonsaiTreeShop.Server.Requests;

namespace BonsaiTreeShop.Server.Extensions;

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