namespace Frank.SolutionManager;

public interface IFile : INamed
{
    FileInfo FileInfo { get; }
    
    string RelativePath { get; }
}