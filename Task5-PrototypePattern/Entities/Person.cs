using Task5_PrototypePattern.Abstractions;

namespace Task5_PrototypePattern.Entities;

/// <summary>
/// Базовый класс Персона
/// </summary>
public class Person: IMyCloneable<Person>
{
    public string Name { get; set; }
    public Address HomeAddress { get; set; } 

    public Person(string name, Address address)
    {
        Name = name;
        HomeAddress = address;
    }

    public Person(Person person)
    {
        Name = person.Name;
        HomeAddress = person.HomeAddress;
    }

    public Person MyClone()
    {
        var clonedPerson = new Person(this);
        clonedPerson.HomeAddress = HomeAddress.MyClone();

        return clonedPerson;
    }
}
