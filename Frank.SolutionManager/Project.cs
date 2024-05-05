namespace Frank.SolutionManager;

public class Project(FileInfo projectFile) : IProject
{
    public string Name { get; } = projectFile.Name;
    public Guid Id { get; } = Guid.NewGuid();
    public FileInfo ProjectFile { get; } = projectFile;
    
    private readonly HashSet<INugetPackage> _nugetPackages = new();
    private readonly HashSet<IProjectReference> _projectReferences = new();

    public IEnumerable<INugetPackage> NugetPackages => _nugetPackages;
    public IEnumerable<IProjectReference> ProjectReferences => _projectReferences;
}