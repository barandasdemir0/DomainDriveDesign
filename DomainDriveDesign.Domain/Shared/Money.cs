namespace DomainDriveDesign.Domain.Shared;

public sealed record Money(decimal Amount,Currency Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new ArgumentException("Para Birimleri birbirinden farklı değerler toplanamaz");
        }
        return new(a.Amount + b.Amount, a.Currency);
    }

    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new(0, currency);

    public bool IsZero() => this == Zero(Currency);
}
