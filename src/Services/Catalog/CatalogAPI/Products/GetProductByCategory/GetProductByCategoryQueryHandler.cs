using Marten.Linq.QueryHandlers;

namespace CatalogAPI.Products.GetCategory
{

    public record GetProductByCategoryQuery(string categoryId):IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    public class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var Products = await session.Query<Product>().Where(x => x.Category.Contains(request.categoryId)).ToListAsync();

            return new GetProductByCategoryResult(Products);
        }
    }
}
