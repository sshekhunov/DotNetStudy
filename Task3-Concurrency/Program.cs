
using System.Diagnostics;


CountSpacesInFiles([@"Samples\File1.txt", @"Samples\File2.txt", @"Samples\File3.txt"]);
CountSpacesInFilesFromDirectory("Samples");

static void CountSpacesInFilesFromDirectory(string path)
{
    if (Directory.Exists(path))
    {
        CountSpacesInFiles(Directory.GetFiles(path));
    }
    else
    {
        throw new Exception($"Directory {path} not found!");
    }
}

static void CountSpacesInFiles(string[] filePaths)
{
    var stopWatch = new Stopwatch();
    var tasks = new List<Task>();

    stopWatch.Start();

    foreach (var file in filePaths)
    {
        tasks.Add(Task.Run(() => Console.WriteLine($"Spaces in file {file}: {CountSpacesInFile(file)}")));
    }
    Task.WaitAll(tasks);

    stopWatch.Stop();

    Console.WriteLine($"Processing time: {stopWatch.Elapsed}");
}


static int CountSpacesInFile(string filePath)
{
    int count = 0;

    if (File.Exists(filePath))
    {
        count = File.ReadAllText(filePath).Count(c => c == ' ');
    }
    else
    {
        throw new Exception($"File {filePath} not found!");
    }

    return count;
}