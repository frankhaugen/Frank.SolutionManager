namespace Frank.SolutionManager;

public interface IContainFolders
{
    IReadOnlySet<IFolder> Folders { get; }
}