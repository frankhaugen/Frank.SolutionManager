namespace Frank.SolutionManager;

public interface IContainFiles
{
    IEnumerable<IFile> Files { get; }
}