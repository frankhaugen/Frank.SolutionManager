using Atom.Util;

namespace Frank.SolutionManager;

public class Solution : ISolution
{
    private readonly HashSet<IFolder> _folders = new();
    private readonly HashSet<IProject> _projects = new();

    public string Name { get; }

    public IReadOnlySet<IFolder> Folders => _folders;
    public IReadOnlySet<IProject> Projects => _projects;

    public required SolutionFileHeader Header { get; init; }

    public required SolutionGlobalSection GlobalSection { get; init; }
    
    [JsonConverter(typeof(FileInfoJsonConverter))]
    public FileInfo SolutionFile { get; }
    
    /// <summary>
    /// Creates a new instance of <see cref="Solution"/>.
    /// </summary>
    /// <param name="solutionFile">The solution file that should not already exist.</param>
    /// <exception cref="ArgumentException">Thrown when the solution file already exists.</exception>
    public Solution(FileInfo solutionFile)
    {
        if (solutionFile.Exists)
            throw new ArgumentException($"The solution file already exists: '{solutionFile.FullName}'\n use Solution.Parse() -method instead", nameof(solutionFile));
        Name = Path.GetFileNameWithoutExtension(solutionFile.Name);
        SolutionFile = solutionFile;
        
        Header = new SolutionFileHeader();
        GlobalSection = new SolutionGlobalSection(new List<SlnFileSection>());
    }
    
    internal Solution(FileInfo solutionFile, string name)
    {
        Name = name;
        SolutionFile = solutionFile;
    }
    
    public ISolution AddProject(IProject project)
    {
        _projects.Add(project);
        return this;
    }

    public ISolution AddProjects(IEnumerable<IProject> projects)
    {
        foreach (var project in projects) _projects.Add(project);
        return this;
    }

    public ISolution AddFolder(IFolder folder)
    {
        _folders.Add(folder);
        return this;
    }

    public ISolution AddFolders(IEnumerable<IFolder> folders)
    {
        foreach (var folder in folders) _folders.Add(folder);
        return this;
    }
}