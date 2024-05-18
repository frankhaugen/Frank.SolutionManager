namespace Frank.SolutionManager;

public class Solution : ISolution
{
    private readonly HashSet<IFolder> _folders = new();
    private readonly HashSet<IProject> _projects = new();
    private readonly HashSet<PlatformSolutionConfiguration> _configurations = new();

    public string Name { get; }
    public IEnumerable<IFolder> Folders => _folders;
    public IEnumerable<IProject> Projects => _projects;
    public IEnumerable<PlatformSolutionConfiguration> Configurations => _configurations;

    public FileInfo SolutionFile { get; }
    
    public Solution(FileInfo solutionFile)
    {
        if (!solutionFile.Exists)
            CreateSolutionFile(solutionFile);
        
        Name = Path.GetFileNameWithoutExtension(solutionFile.Name);
        SolutionFile = solutionFile;
    }

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

    /// <inheritdoc />
    ISolution ISolution.AddProject(IProject project)
    {
        _projects.Add(project);
        return this;
    }

    /// <inheritdoc />
    public ISolution AddProjects(IEnumerable<IProject> projects)
    {
        foreach (var project in projects)
            _projects.Add(project);
        return this;
    }

    /// <inheritdoc />
    ISolution ISolution.AddFolder(IFolder folder)
    {
        _folders.Add(folder);
        return this;
    }

    /// <inheritdoc />
    public ISolution AddFolders(IEnumerable<IFolder> folders)
    {
        foreach (var folder in folders)
            _folders.Add(folder);
        return this;
    }

    /// <inheritdoc />
    public ISolution AddConfiguration(PlatformSolutionConfiguration configuration)
    {
        _configurations.Add(configuration);
        return this;
    }

    /// <inheritdoc />
    public ISolution AddConfigurations(IEnumerable<PlatformSolutionConfiguration> configurations)
    {
        foreach (var configuration in configurations)
            _configurations.Add(configuration);
        return this;
    }

    /// <inheritdoc />
    public IEnumerable<IProject> GetAllProjects()
    {
        var allProjects = new List<IProject>();
        allProjects.AddRange(Projects);
        foreach (var folder in Folders)
            allProjects.AddRange(folder.GetAllProjects());
        return allProjects;
    }

    private static void CreateSolutionFile(FileInfo solutionFile)
    {
        solutionFile.Refresh();
        solutionFile.Directory!.Create();
        solutionFile.Refresh();
        System.IO.File.WriteAllText(solutionFile.FullName, string.Empty);
    }

    public void AddProject(IProject project) => _projects.Add(project);
    
    public void AddFolder(IFolder folder) => _folders.Add(folder);

}