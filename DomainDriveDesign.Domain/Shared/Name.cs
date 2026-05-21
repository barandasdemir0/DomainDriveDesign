namespace DomainDriveDesign.Domain.Shared;

public sealed record Name
{
    public string Value { get; init; }
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("İsim Alanı Boş Olamaz");
        }
        if (value.Length < 3)
        {
            throw new ArgumentException("İsim Alanı 3 karakterden az olamaz");
        }
        Value = value;
    }
}
