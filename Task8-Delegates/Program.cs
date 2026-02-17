using Task8_Delegates;

// GetMax
var people = new[]
{
    new Person("Анна", 25),
    new Person("Борис", 30),
    new Person("Виктор", 22),
};

var oldest = people.GetMax(p => p.Age);
Console.WriteLine($"Самый старший: {oldest?.Name}, возраст {oldest?.Age}");
Console.WriteLine();

// FileSearcher 
var fileCount = 0;
const int cancelAfterFiles = 10;

var searcher = new FileSearcher();

searcher.FileFound += (sender, args) =>
{
    Console.WriteLine($"Найден файл: {args.FileName}");
    fileCount++;
    if (fileCount >= cancelAfterFiles)
    {
        Console.WriteLine($"Отмена поиска после {cancelAfterFiles} файлов.");
        args.Cancel = true;
    }
};

Console.Write("Введите путь к каталогу: ");
var searchPath = (Console.ReadLine() ?? "").Trim();
Console.WriteLine($"Поиск файлов в каталоге: {searchPath}");

try
{
    searcher.Search(searchPath);
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка поиска: {ex.Message}");
}

record Person(string Name, int Age);
