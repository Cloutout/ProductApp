namespace ProductApp.Domain.Aggregates.Product.ValueObject
{
    public sealed class Stock
    {
        public int Quantity { get; }// DDD de value object immutable olmalidir o yuzden property'ler set edilemez

        public Stock(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Stok 0 dan kucuk olamaz");
            Quantity = quantity;
        }

        public Stock Add(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Stoga eklenecek miktar 0 dan buyuk olmali");
            return new Stock(Quantity + amount);
        }

        public Stock Remove(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Stoktan dusurulecek miktar 0 dan buyuk olmali");
            if (amount > Quantity)
                throw new InvalidOperationException("Stoktan dusulecek miktar mevcut stoktan kucuk olmali");
            return new Stock(Quantity - amount);
        }

        //public override bool Equals(object obj) => Equals(obj as Stock);

        //public bool Equals(Stock? other) => other != null && Quantity == other.Quantity;

        //public override int GetHashCode() => Quantity.GetHashCode();

        //yukarida ki kodlari gpt onerdi ama pek anlamadim o yuzden yorum satiri yaptim
        //Nesneler hash tabanlı koleksiyonlarda (örneğin HashSet<T>, Dictionary<TKey,TValue>) kullanılırken, eşit olan nesnelerin hash kodlarının da eşit olması gerekir.
        //Equals(object obj): .NET’in temel object sınıfından gelen standart eşitlik metodu.
        //Equals(Stock other): Tip güvenli eşitlik kontrolü için ayrıca implement edilmiş IEquatable<Stock> arayüzünün metodu.
    }

}
