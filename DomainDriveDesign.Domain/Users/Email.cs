namespace DomainDriveDesign.Domain.Users;

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("Email Alanı Boş Olamaz");
        }
        if (value.Length < 3)
        {
            throw new ArgumentException("Email Alanı 3 karakterden az olamaz");
        }
        if (!value.Contains("@"))
        {
            throw new ArgumentException("Bu geçerli bir Email Alanı değildir");
        }

        Value = value;
    }
}
