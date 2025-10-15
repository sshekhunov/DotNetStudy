namespace Task5_PrototypePattern.Entities;

/// <summary>
/// Класс Менеджер, наследник Сотрудника
/// </summary>
public class Manager : Employee
{
    public int TeamSize { get; set; }
    public string ProjectName { get; set; }

    public Manager(string name, Address address, string position, int teamSize, string projectName)
        : base(name, address, position)
    {
        TeamSize = teamSize;
        ProjectName = projectName;
    }

    public Manager(Manager manager)
        : base(manager)
    {
        TeamSize = manager.TeamSize;
        ProjectName = manager.ProjectName;
    }

    public new Manager MyClone()
    {
        return new Manager(this);
    }
}
