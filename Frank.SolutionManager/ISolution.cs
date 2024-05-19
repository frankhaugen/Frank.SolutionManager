namespace Frank.SolutionManager;

public interface ISolution : INamed, IContainFolders, IContainProjects
{
    SolutionFileHeader Header { get; }
    SolutionGlobalSection GlobalSection { get; }
    FileInfo SolutionFile { get; }
    
    ISolution AddProject(IProject project);
    ISolution AddProjects(IEnumerable<IProject> projects);
    
    ISolution AddFolder(IFolder folder);
    ISolution AddFolders(IEnumerable<IFolder> folders);
    
    public static ISolution FromFile(FileInfo fileInfo) => SolutionFileHelper.ParseSolution(fileInfo);

}