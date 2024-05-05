namespace Frank.SolutionManager;

public static class SolutionReader
{
    private static readonly ISolutionItemFactory ItemFactory = new SolutionItemFactory();
    
    public static ISolution ReadSolution(FileInfo solutionFile)
    {
        var solution = new Solution(solutionFile);
        // Example: Parse the solution file and create projects and folders
        var lines = System.IO.File.ReadAllLines(solutionFile.FullName);
        foreach (var line in lines)
        {
            if (line.StartsWith("Project(\""))
            {
                var projectDetails = ParseProjectDetails(line);
                var project = ItemFactory.CreateProject(new FileInfo(projectDetails.path));
                // Assume solution has a way to add projects
                solution.AddProject(project);
            }
        }

        return solution;
    }

    private static (string name, Guid id, string path) ParseProjectDetails(string line)
    {
        // Placeholder: parse details from the line
        return ("ProjectName", Guid.NewGuid(), "ProjectPath");
    }
}