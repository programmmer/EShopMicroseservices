
namespace CatalogAPI.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, decimal Price, List<string> Category, string ImageFile, string Description) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool isSucceeded);



    public class UpdateProductCommandHandler(IDocumentSession documentSession) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
          var product=  await documentSession.LoadAsync<Product>(request.Id, cancellationToken);
            if (product is null) {
                throw new ProductNotFoundException();
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Category = request.Category;
            product.ImageFile = request.ImageFile;
            product.Description = request.Description;

            documentSession.Update(product);
           await documentSession.SaveChangesAsync();

            return new UpdateProductResult(true);
        }
    }
}
