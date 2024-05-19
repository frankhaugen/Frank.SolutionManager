using Frank.SolutionManager.Legacy.Sections;
using SlnParser.Contracts;

namespace Frank.SolutionManager.Legacy;

public class Solution : ISolution
{
    private readonly HashSet<IFolder> _folders = new();
    private readonly HashSet<IProject> _projects = new();
    private readonly HashSet<PlatformSolutionConfiguration> _configurations = new();
    private IReadOnlyCollection<IProject> _projects1;

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public FileInfo? File { get; set; }

    /// <inheritdoc />
    public string FileFormatVersion { get; set; }

    /// <inheritdoc />
    public VisualStudioVersion VisualStudioVersion { get; set; }
    public IEnumerable<IFolder> Folders => _folders;

    /// <inheritdoc />
    public IReadOnlyCollection<IProject> AllProjects { get; set; }

    /// <inheritdoc />
    IReadOnlyCollection<IProject> ISolution.Projects => _projects1;

    /// <inheritdoc />
    public IReadOnlyCollection<ConfigurationPlatform> ConfigurationPlatforms { get; set; }

    /// <inheritdoc />
    public Guid? Guid { get; set; }
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
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<string> GetSolutionFileContentAsync()
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public ISolution AddProjects(IEnumerable<IProject> projects)
    {
        foreach (var project in projects)
            _projects.Add(project);
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

    private static void CreateSolutionFile(FileInfo solutionFile)
    {
        solutionFile.Refresh();
        solutionFile.Directory!.Create();
        solutionFile.Refresh();
        System.IO.File.WriteAllText(solutionFile.FullName, string.Empty);
    }


}