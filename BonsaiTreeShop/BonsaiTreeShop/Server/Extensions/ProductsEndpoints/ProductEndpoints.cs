using BonsaiTreeShop.Server.Requests.Deletes.ProductDelete;
using BonsaiTreeShop.Server.Requests.Gets.ProductGets;
using BonsaiTreeShop.Server.Requests.Posts.ProductPost;
using BonsaiTreeShop.Server.Requests.Puts.ProductPut;

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