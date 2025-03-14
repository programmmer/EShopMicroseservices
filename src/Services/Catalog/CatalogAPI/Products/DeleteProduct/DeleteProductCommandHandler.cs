
namespace CatalogAPI.Products.DeleteProduct
{

    public record DeleteProductCommand(Guid id):ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool isSucceeded);
    public class DeleteProductCommandHandler(IDocumentSession documentSession) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            documentSession.Delete<Product>(request.id);

          await  documentSession.SaveChangesAsync();

            return new DeleteProductResult(true);
        }
    }
}
