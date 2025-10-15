namespace Task5_PrototypePattern.Entities;

/// <summary>
/// Класс Сотрудник, наследник Персоны
/// </summary>
public class Employee : Person
{
    public string Position { get; set; }

    public Employee(string name, Address address, string position)
        : base(name, address)
    {
        Position = position;
    }

    public Employee(Employee employee)
        : base(employee)
    {
        Position = employee.Position;
    }

    public new Employee MyClone()
    {
        return new Employee(this);
    }
}
