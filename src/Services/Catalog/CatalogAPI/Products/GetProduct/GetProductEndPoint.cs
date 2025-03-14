
namespace CatalogAPI.Products.GetProduct
{

    // public record GetProductRequest();

    public record GetProductResponse(Product Product);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/{Id}", async (Guid Id, ISender sender) =>
            {

                var product = sender.Send(new GetProductQuery(Id));

                var result = product.Adapt<GetProductResponse>();

                Results.Ok(result);

            }).WithName("GetProductById").
            Produces<GetProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
