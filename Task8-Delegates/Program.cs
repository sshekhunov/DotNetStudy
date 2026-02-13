using Task8_Delegates;

var people = new[]
{
    new Person("Анна", 25),
    new Person("Борис", 30),
    new Person("Виктор", 22),
};

var oldest = people.GetMax(p => p.Age);
Console.WriteLine($"Самый старший: {oldest?.Name}, возраст {oldest?.Age}");

record Person(string Name, int Age);
