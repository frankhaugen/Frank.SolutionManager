namespace Frank.SolutionManager;

public interface ISolution : INamed, IContainFolders, IContainProjects, IContainConfigurations, IFlatProjectsGetter
{
    FileInfo SolutionFile { get; }
    
    Task WriteSolutionFileAsync();
    
    Task<string> GetSolutionFileContentAsync();
    
    ISolution AddProject(IProject project);
    ISolution AddProjects(IEnumerable<IProject> projects);
    
    ISolution AddFolder(IFolder folder);
    ISolution AddFolders(IEnumerable<IFolder> folders);
    
    ISolution AddConfiguration(PlatformConfiguration configuration);
    ISolution AddConfigurations(IEnumerable<PlatformConfiguration> configurations);
    
}