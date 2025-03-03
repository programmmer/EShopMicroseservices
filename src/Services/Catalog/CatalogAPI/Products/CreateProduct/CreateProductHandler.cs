using MediatR;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductRequest(string Name, decimal Price, List<string> Category, string ImageFile, string Description):IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);


    public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
