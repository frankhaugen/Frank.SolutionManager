namespace Frank.SolutionManager;

public interface IFlatProjectsGetter
{
    IEnumerable<IProject> GetAllProjects();
}