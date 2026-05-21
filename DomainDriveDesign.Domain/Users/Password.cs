namespace DomainDriveDesign.Domain.Users;

public sealed record Password
{
    public string Value { get; init; }
    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("Şifre Alanı Boş Olamaz");
        }
        if (value.Length < 6)
        {
            throw new ArgumentException("Şifre Alanı 6 karakterden az olamaz");
        }
        Value = value;
    }
}
