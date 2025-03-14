using CatalogAPI.Models;
using CatalogAPI.Products.CreateProduct;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CatalogAPI.Products.GetProducts
{
    //public record GetProductRequest();

    public record GetProductResponse(IEnumerable<Product> Products);

    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) => {

               var products=await sender.Send(new GetProductsQuery());

               var result = products.Adapt<GetProductResponse>();

                return Results.Ok(result);

            }).WithName("products").
            Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("GET Product").
            WithDescription("GET Product");
        }
    }
}
