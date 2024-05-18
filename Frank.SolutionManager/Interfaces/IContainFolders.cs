namespace Frank.SolutionManager;

public interface IContainFolders
{
    IEnumerable<IFolder> Folders { get; }
}