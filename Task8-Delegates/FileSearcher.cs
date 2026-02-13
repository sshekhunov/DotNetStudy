namespace Task8_Delegates;

public class FileSearcher
{
    public event EventHandler<FileArgs>? FileFound;

    public void Search(string directoryPath, CancellationToken cancellationToken = default)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"Каталог не найден: {directoryPath}");
        }
        SearchRecursive(directoryPath, cancellationToken);
    }

    private void SearchRecursive(string directoryPath, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        string[] files;
        string[] subdirs;

        files = Directory.GetFiles(directoryPath);
        subdirs = Directory.GetDirectories(directoryPath);

        foreach (var filePath in files)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var fileInfo = new FileInfo(filePath);
            var args = new FileArgs(fileInfo.Name);
            FileFound?.Invoke(this, args);
        }

        foreach (var subdir in subdirs)
        {
            SearchRecursive(subdir, cancellationToken);
        }
    }
}
