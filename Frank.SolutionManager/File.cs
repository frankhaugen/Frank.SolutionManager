namespace Frank.SolutionManager;

public class File(FileInfo fileInfo) : IFile
{
    public string Name { get; } = fileInfo.Name;
    public FileInfo FileInfo { get; } = fileInfo;
}