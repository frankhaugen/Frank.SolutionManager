namespace Frank.SolutionManager;

public interface IProjectReference
{
    FileInfo ProjectReferenceFile { get; }
    string RelativePath { get; }
}