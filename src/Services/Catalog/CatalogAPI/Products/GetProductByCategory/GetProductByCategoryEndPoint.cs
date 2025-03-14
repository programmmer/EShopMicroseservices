
namespace CatalogAPI.Products.GetCategory
{
    //public record GetProductByCategoryRequest();
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{CategoryId}", async (string CategoryId,ISender sender) => {

               var products= await sender.Send(new GetProductByCategoryQuery(CategoryId));

               var repones= products.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(repones);
            });
        }
    }
}
