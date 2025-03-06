using Buliding_Blocks;
using CatalogAPI.Models;
using Marten;
using MediatR;
using System.Windows.Input;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductCommand(string Name, decimal Price, List<string> Category, string ImageFile, string Description) :
        ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);


    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Category = request.Category,
                ImageFile = request.ImageFile,
                Description = request.Description

            };
            session.Store(product);
            await session.SaveChangesAsync();

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
