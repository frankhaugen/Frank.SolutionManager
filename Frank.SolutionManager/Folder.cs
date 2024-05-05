namespace Frank.SolutionManager;

public class Folder : IFolder
{
    public string Name { get; }
    public Guid Id { get; } = Guid.NewGuid();
    public IEnumerable<IFolder> Folders { get; }
    
    public IEnumerable<IProject> Projects { get; }

    public IEnumerable<IFile> Files { get; }
    
    public Folder(string name)
    {
        Name = name;
    }
}