namespace Frank.SolutionManager;

public interface IContainProjects
{
    IEnumerable<IProject> Projects { get; }
}