using Buliding_Blocks;
using CatalogAPI.Models;
using Marten;
using Marten.Linq.QueryHandlers;

namespace CatalogAPI.Products.GetProducts
{
  
    public record GetProductsQuery:IQuery<GetProductsResult>;

     public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductsQueryHandler(IDocumentSession _documentSession) :
        IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async  Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var Products = await _documentSession.Query<Product>().ToListAsync();

            return new GetProductsResult(Products);
        }
    }
}
