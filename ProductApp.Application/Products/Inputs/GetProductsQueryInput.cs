namespace ProductApp.Application.Products.Inputs
{
    public record GetProductsQueryInput 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
