namespace Frank.SolutionManager;

public static class SolutionParser
{
    public static ISolution Parse(FileInfo solutionFileInfo)
    {
        var parser = new SlnParser.SolutionParser();
        
        var parsedSolution = parser.Parse(solutionFileInfo);
        
        var solution = new Solution(solutionFileInfo);

        var folders = parsedSolution.Projects
            .Where(p => p.Type == SlnParser.Contracts.ProjectType.SolutionFolder)
            .Cast<SlnParser.Contracts.SolutionFolder>()
            .Select(f => new Folder(f.Name, f.Id).AddFiles(f.Files.Select(x => new File(x, GetRelativePath(solutionFileInfo, x)))))
            .ToList();

        var projects = parsedSolution.Projects
            .Where(p => p.Type != SlnParser.Contracts.ProjectType.SolutionFolder)
            .Cast<SlnParser.Contracts.SolutionProject>()
            .Select(p => new Project(p.File, p.Id));
        
        solution.AddProjects(projects);
        solution.AddFolders(folders);
        
        return solution;
    }

    private static string GetRelativePath(FileInfo solutionFileInfo, FileInfo fileInfo) => Path.GetRelativePath(solutionFileInfo.DirectoryName!, fileInfo.DirectoryName!);
}