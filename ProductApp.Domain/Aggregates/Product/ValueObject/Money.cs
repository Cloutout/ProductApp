namespace ProductApp.Domain.Aggregates.Product.ValueObject;

public sealed class Money
{
    public decimal Amount { get; private set; }

    private Money() { } // EF Core için

    public Money(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Fiyat 0'dan büyük olmalı");

        Amount = amount;
    }
}