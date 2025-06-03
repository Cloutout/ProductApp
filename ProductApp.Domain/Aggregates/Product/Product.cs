 using ProductApp.Domain.Aggregates.Product.ValueObject;

 namespace ProductApp.Domain.Aggregates.Product
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Stock Stock { get; private set; }

        private Product(){ }// EF Core için gerekli boş constructor
        //bunun icinin bos olmasinin sebebi efcore varlik olustururken parametresiz constructor kullanir reflection icin

        public Product(string name, decimal price, Stock stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ürün adı boş olamaz.", nameof(name));
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Fiyat 0'dan büyük olmalıdır.");
            if (stock == null)
                throw new ArgumentNullException(nameof(stock), "Stok bilgisi boş olamaz.");

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
