namespace Frank.SolutionManager;

public static class ProjectReader
{
    public static IProject ReadProject(FileInfo projectFile)
    {
        var project = new Project(projectFile);
        
        // Read project file and populate project object
        
        return project;
    }
}