using BonsaiTreeShop.Server.Requests.Deletes.ProductDelete;
using BonsaiTreeShop.Server.Requests.Gets.ProductGets;
using BonsaiTreeShop.Server.Requests.Posts.ProductPost;
using BonsaiTreeShop.Server.Requests.Puts.ProductPut;

namespace BonsaiTreeShop.Server.Extensions.ProductsEndpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllProductRequest>("/api/products");
        app.MediateGet<GetProductByIdRequest>("/api/products/{id}");

        app.MediatePost<PostProductRequest>("/api/addProduct");

        app.MediatePut<UpdateProductRequest>("/api/updateProduct/{id}");

        app.MediateDelete<DeleteProductRequest>("/api/deleteProduct/{id}");

    }
}