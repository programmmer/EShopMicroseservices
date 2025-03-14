

namespace CatalogAPI.Products.GetProduct
{
  
    public record GetProductQuery(Guid id):IQuery<GetProductResult>;

    public record GetProductResult(Product Product);


    public class GetProductQueryHandler(IDocumentSession  session) : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
           var product=await session.LoadAsync<Product>(request.id, cancellationToken);

            if (product is  null) {
                throw new ProductNotFoundException();
            }

            return new GetProductResult(product);
        }
    }
}
