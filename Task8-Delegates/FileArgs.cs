namespace Task8_Delegates;

public class FileArgs : EventArgs
{
    public string FileName { get; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
    }
}
