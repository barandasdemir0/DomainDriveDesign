namespace DomainDriveDesign.Domain.Shared;

public sealed record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("Usd");
    public static readonly Currency TRY = new("TRY");
    public string Code { get; init; }

    private Currency(string value)
    {
        Code = value;
    }
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ?? throw new ArgumentException("Geçerli Bir para birimi giriniz");
    }
    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        TRY
    };


}
