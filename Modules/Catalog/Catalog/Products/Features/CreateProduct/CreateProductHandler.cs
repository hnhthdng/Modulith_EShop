using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Features.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string imageFile, decimal price) : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductHandler :IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
