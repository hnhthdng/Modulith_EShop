using Shared.Pagination;

namespace Catalog.Products.Features.GetProducts
{
    public record GetProductsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetProductsResult>;
    public record GetProductsResult(PaginatedResult<ProductDto> Products);

    internal class GetProductsHandlerGetProductsHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Products.LongCountAsync(cancellationToken);

            var products = await dbContext.Products
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            //mapping product entity to ProductDto using Mapster
            var productDtos = products.Adapt<List<ProductDto>>();

            return new GetProductsResult(new PaginatedResult<ProductDto>(
                pageIndex,
                pageSize,
                totalCount,
                productDtos
                ));
        }

    }
}
