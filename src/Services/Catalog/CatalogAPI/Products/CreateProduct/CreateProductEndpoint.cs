namespace CatalogAPI.Products.CreateProduct
{


    public record class CreateProductRequest(string Name, decimal Price, List<string> Category, string ImageFile, string Description);

    public record class CreateProductResponse(Guid Id);


    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Products", async (CreateProductRequest createProductRequest, ISender sender) =>
            {

                var command = createProductRequest.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);

            }).
            WithName("CreateProduct").
            Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Create Product").
            WithDescription("Create Product");
        }
    }
}
