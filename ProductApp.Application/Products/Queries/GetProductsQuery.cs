using ProductApp.Application.Common;
using ProductApp.Application.Products.Inputs;
using ProductApp.Application.Products.Outputs;

namespace ProductApp.Application.Products.Queries
{
    public class GetProductsQuery
    {
        private readonly IProductRepository _repository;

        public GetProductsQuery(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductsQueryOutput>> Handle(GetProductsQueryInput request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);
            return products.Select(p => new GetProductsQueryOutput
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
        }
    }
}
