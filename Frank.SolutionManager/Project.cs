namespace Frank.SolutionManager;

public class Project(FileInfo projectFile, Guid id) : IProject
{
    public string Name { get; } = Path.GetFileNameWithoutExtension(projectFile.Name);
    public Guid Id { get; } = id;
    public FileInfo ProjectFile { get; } = projectFile;
    
    private readonly HashSet<INugetPackage> _nugetPackages = new();
    private readonly HashSet<IProjectReference> _projectReferences = new();

    public IEnumerable<INugetPackage> NugetPackages => _nugetPackages;
    public IEnumerable<IProjectReference> ProjectReferences => _projectReferences;

    public IProject AddNugetPackage(INugetPackage nugetPackage)
    {
        _nugetPackages.Add(nugetPackage);
        return this;
    }

    public IProject AddProjectReference(IProjectReference projectReference)
    {
        _projectReferences.Add(projectReference);
        return this;
    }

    public IProject AddNugetPackages(IEnumerable<INugetPackage> nugetPackages)
    {
        foreach (var nugetPackage in nugetPackages) _nugetPackages.Add(nugetPackage);
        return this;
    }

    public IProject AddProjectReferences(IEnumerable<IProjectReference> projectReferences)
    {
        foreach (var projectReference in projectReferences) _projectReferences.Add(projectReference);
        return this;
    }

    /// <inheritdoc />
    public string GetRelativePath() => Path.GetRelativePath(ProjectFile.Directory?.Parent?.FullName ?? projectFile.Name, ProjectFile.FullName);
}