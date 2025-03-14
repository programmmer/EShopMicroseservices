
using System.Net;

namespace CatalogAPI.Products.DeleteProduct
{
   // public record DeleteProductRequest();
    public record DeleteProductResponse(bool isSucceeded);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id,ISender sender) => {

               var resuslt= await sender.Send(new DeleteProductCommand(id));

               var response= resuslt.Adapt<DeleteProductResponse>();

                Results.Ok(response.isSucceeded);
            })
                .WithName("Delete Product")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)                
                ;
        }
    }
}
