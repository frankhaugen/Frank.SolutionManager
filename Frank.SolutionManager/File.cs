namespace Frank.SolutionManager;

public class File(FileInfo fileInfo, string relativePath) : IFile
{
    public string Name { get; } = fileInfo.Name;
    public FileInfo FileInfo { get; } = fileInfo;
    public string RelativePath => Path.Combine(relativePath, Name); 
}