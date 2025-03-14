
namespace CatalogAPI.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, decimal Price, List<string> Category, string ImageFile, string Description);
    public record UpdateProductResponse(bool isSucceeded);

    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/Product", async (UpdateProductRequest UpdateProductRequest,ISender sender ) =>
            {
               var updatedProduct= UpdateProductRequest.Adapt<UpdateProductCommand>();

              var result= await sender.Send(updatedProduct);

                return Results.Ok(new UpdateProductResponse(result.isSucceeded));
            });
        }
    }
}
