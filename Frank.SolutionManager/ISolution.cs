namespace Frank.SolutionManager;

public interface ISolution : INamed, IContainFolders, IContainProjects
{
    FileInfo SolutionFile { get; }
    
    Task WriteSolutionFileAsync();
    
    Task<string> GetSolutionFileContentAsync();
}