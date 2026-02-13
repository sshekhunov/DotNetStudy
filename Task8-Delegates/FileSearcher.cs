namespace Task8_Delegates;

public class FileSearcher
{
    public event EventHandler<FileArgs>? FileFound;
    private bool _cancelRequested;

    public void Search(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"Каталог не найден: {directoryPath}");
        }

        _cancelRequested = false;
        SearchRecursive(directoryPath);
    }

    private void SearchRecursive(string directoryPath)
    {
        string[] files;
        string[] subdirs;

        files = Directory.GetFiles(directoryPath);
        subdirs = Directory.GetDirectories(directoryPath);


        foreach (var filePath in files)
        {
            var fileInfo = new FileInfo(filePath);
            var args = new FileArgs(
                fileInfo.Name);

            FileFound?.Invoke(this, args);

            if (args.Cancel)
            {
                _cancelRequested = true;
                return;
            }
        }

        foreach (var subdir in subdirs)
        {
            SearchRecursive(subdir);
            if (_cancelRequested)
                return;
        }
    }
}
