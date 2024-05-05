namespace Frank.SolutionManager;

public class SolutionItemFactory : ISolutionItemFactory
{
    public Project CreateProject(FileInfo projectFile)
    {
        return new Project(projectFile);
    }

    public Folder CreateFolder(string name)
    {
        return new Folder(name);
    }
}