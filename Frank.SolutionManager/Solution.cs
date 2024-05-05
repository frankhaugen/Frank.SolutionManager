namespace Frank.SolutionManager;

public class Solution : ISolution
{
    private readonly HashSet<IFolder> _folders = new();
    private readonly HashSet<IProject> _projects = new();

    public string Name { get; }
    public IEnumerable<IFolder> Folders => _folders;
    public IEnumerable<IProject> Projects => _projects;

    public FileInfo SolutionFile { get; }

    /// <inheritdoc />
    public async Task WriteSolutionFileAsync()
    {
        await SolutionWriter.WriteSolutionFileAsync(SolutionFile.Directory, this);
    }

    /// <inheritdoc />
    public async Task<string> GetSolutionFileContentAsync()
    {
        return await SolutionWriter.GetSolutionFileContentAsync(this);
    }

    public Solution(FileInfo solutionFile)
    {
        if (!solutionFile.Exists)
            throw new FileNotFoundException("Solution file not found.", SolutionFile.FullName);
        
        Name = Path.GetFileNameWithoutExtension(solutionFile.Name);
        SolutionFile = solutionFile;
    }

    public void AddProject(IProject project) => _projects.Add(project);
    
    public void AddFolder(IFolder folder) => _folders.Add(folder);
}