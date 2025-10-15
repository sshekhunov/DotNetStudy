using Task5_PrototypePattern.Abstractions;

namespace Task5_PrototypePattern.Entities;

/// <summary>
/// Класс с адресом персоны
/// </summary>
public class Address: IMyCloneable<Address>
{
    public string City { get; set; }
    public string Street { get; set; }

    public Address(string city, string street)
    {
        City = city;
        Street = street;
    }

    public Address MyClone()
    {
        return (Address)MemberwiseClone();
    }
}
