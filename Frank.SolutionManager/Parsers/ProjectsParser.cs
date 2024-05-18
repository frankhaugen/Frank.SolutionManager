namespace Frank.SolutionManager.Parsers;

public static class ProjectsParser
{
    public static IEnumerable<IProject> ParseProjects(FileInfo solutionFileInfo)
    {
        var projects = new List<IProject>();
        
        var projectSections = solutionFileInfo.FindAll("Project(", "EndProject");
        return projects;
    }
}