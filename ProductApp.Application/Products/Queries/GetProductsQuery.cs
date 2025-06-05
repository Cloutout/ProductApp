using MediatR;
using ProductApp.Application.Common;
using ProductApp.Application.Common.Pagination;
using ProductApp.Application.Products.Outputs;

namespace ProductApp.Application.Products.Queries
{
    public record GetProductsQuery(int PageNumber, int PageSize) : IRequest<PagedResult<GetProductsQueryOutput>>;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResult<GetProductsQueryOutput>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<GetProductsQueryOutput>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
           
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = request.PageSize <= 0 ? 25 : request.PageSize;

            var products = await _repository.GetPagedAsync(pageNumber, pageSize);

            var items = products.Select(p => new GetProductsQueryOutput
            {
                
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return new PagedResult<GetProductsQueryOutput>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}