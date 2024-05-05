namespace Frank.SolutionManager;

public interface ISolutionItemFactory
{
    Project CreateProject(FileInfo projectFile);
    Folder CreateFolder(string name);
}