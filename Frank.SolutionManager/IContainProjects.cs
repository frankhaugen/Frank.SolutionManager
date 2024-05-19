namespace Frank.SolutionManager;

public interface IContainProjects
{
    IReadOnlySet<IProject> Projects { get; }
}