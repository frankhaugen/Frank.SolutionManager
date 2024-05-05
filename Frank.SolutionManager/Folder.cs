namespace Frank.SolutionManager;

public class Folder : IFolder
{
    private readonly HashSet<IProject> _projects = new();
    private readonly HashSet<IFolder> _folders = new();
    private readonly HashSet<IFile> _files = new();
    
    public string Name { get; }
    public Guid Id { get; } = Guid.NewGuid();

    public IEnumerable<IFolder> Folders => _folders;
    public IEnumerable<IProject> Projects => _projects;
    public IEnumerable<IFile> Files => _files;

    public Folder(string name)
    {
        Name = name;
    }
    
    public Folder(string name, Guid id)
    {
        Name = name;
        Id = id;
    }

    public IFolder AddFolder(IFolder folder)
    {
        _folders.Add(folder);
        return this;
    }

    public IFolder AddProject(IProject project)
    {
        _projects.Add(project);
        return this;
    }

    public IFolder AddFile(IFile file)
    {
        _files.Add(file);
        return this;
    }

    public IFolder AddFolders(IEnumerable<IFolder> folders)
    {
        foreach (var folder in folders) _folders.Add(folder);
        return this;
    }

    public IFolder AddProjects(IEnumerable<IProject> projects)
    {
        foreach (var project in projects) _projects.Add(project);
        return this;
    }

    public IFolder AddFiles(IEnumerable<IFile> files)
    {
        foreach (var file in files) _files.Add(file);
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
}