namespace ProductApp.Domain.Aggregates.Product.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) : base(message) { }

    }
}
