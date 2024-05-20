using System.Xml.Linq;

namespace Frank.SolutionManager;

public class Project : IProject
{
    public string Name { get; }
    public Guid Id { get; }
    
    public XDocument Document { get; private set; }
    
    [JsonConverter(typeof(FileInfoJsonConverter))]
    public FileInfo ProjectFile { get; }
    
    private readonly HashSet<INugetPackage> _nugetPackages = new();
    private readonly HashSet<IProjectReference> _projectReferences = new();

    public Project(FileInfo projectFile)
    {
        Name = Path.GetFileNameWithoutExtension(projectFile.Name);
        Id = Guid.NewGuid();
        ProjectFile = projectFile;
        Document = CsprojManipulator.CreateNew();
    }
    
    public Project(FileInfo projectFile, Guid id)
    {
        Name = Path.GetFileNameWithoutExtension(projectFile.Name);
        Id = id;
        ProjectFile = projectFile;
    }
    
    public Project(FileInfo projectFile, Guid id, IEnumerable<INugetPackage> nugetPackages, IEnumerable<IProjectReference> projectReferences)
    {
        Name = Path.GetFileNameWithoutExtension(projectFile.Name);
        Id = id;
        ProjectFile = projectFile;
        _nugetPackages = new HashSet<INugetPackage>(nugetPackages);
        _projectReferences = new HashSet<IProjectReference>(projectReferences);
        Document = CsprojManipulator.LoadProjectFile(projectFile);
    }
    
    public Project(FileInfo projectFile, Guid id, XDocument document)
    {
        Name = Path.GetFileNameWithoutExtension(projectFile.Name);
        Id = id;
        ProjectFile = projectFile;
        Document = document;
        
        var nugetPackages = CsprojManipulator.GetNugetPackages(Document);
        var projectReferences = CsprojManipulator.GetProjectReferences(Document);
        
        _nugetPackages = new HashSet<INugetPackage>(nugetPackages);
        _projectReferences = new HashSet<IProjectReference>(projectReferences);
    }

    public IEnumerable<INugetPackage> NugetPackages => _nugetPackages;
    public IEnumerable<IProjectReference> ProjectReferences => _projectReferences;

    /// <inheritdoc />
    public IProject AddNugetPackage(INugetPackage nugetPackage)
    {
        _nugetPackages.Add(nugetPackage);
        return this;
    }

    /// <inheritdoc />
    public IProject AddProjectReference(IProjectReference projectReference)
    {
        _projectReferences.Add(projectReference);
        return this;
    }

    /// <inheritdoc />
    public IProject AddNugetPackages(IEnumerable<INugetPackage> nugetPackages)
    {
        foreach (var nugetPackage in nugetPackages)
        {
            _nugetPackages.Add(nugetPackage);
        }
        return this;
    }

    /// <inheritdoc />
    public IProject AddProjectReferences(IEnumerable<IProjectReference> projectReferences)
    {
        foreach (var projectReference in projectReferences)
        {
            _projectReferences.Add(projectReference);
        }
        return this;
    }

    /// <inheritdoc />
    public string GetRelativePath(DirectoryInfo solutionDirectory)
    {
        return Path.GetRelativePath(solutionDirectory.FullName, ProjectFile.Directory?.FullName ?? ProjectFile.FullName);
    }
}