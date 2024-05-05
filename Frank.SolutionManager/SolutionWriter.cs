using System.Text;

namespace Frank.SolutionManager;

public static class SolutionWriter
{
    private static readonly StringBuilder SolutionFileContent = new();

    public static async Task WriteSolutionFileAsync(DirectoryInfo solutionDirectory, ISolution solution)
    {
        var content = await GetSolutionFileContentAsync(solution);
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, $"{solution.Name}.sln"));
        await using var writer = new StreamWriter(solutionFile.FullName, false, Encoding.UTF8);
        await writer.WriteAsync(content);
    }

    private static void AppendHeader()
    {
        SolutionFileContent.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
        SolutionFileContent.AppendLine("# Visual Studio Version 16");
        SolutionFileContent.AppendLine("VisualStudioVersion = 16.0.31105.61");
        SolutionFileContent.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");
    }

    private static void AppendProjectsAndFolders(ISolution solution)
    {
        foreach (var project in solution.Projects)
        {
            SolutionFileContent.AppendLine($"Project(\"{{{project.Id}}}\") = \"{project.Name}\", \"{project.ProjectFile.Name}\", \"{{{project.Id}}}\"");
            SolutionFileContent.AppendLine("EndProject");
        }
        
        foreach (var folder in solution.Folders)
        {
            SolutionFileContent.AppendLine($"Project(\"{{{folder.Id}}}\") = \"{folder.Name}\", \"{folder.Name}\", \"{{{folder.Id}}}\"");
            SolutionFileContent.AppendLine("EndProject");
        }
        
        
    }

    public static async Task<string> GetSolutionFileContentAsync(ISolution solution)
    {
        SolutionFileContent.Clear();
        AppendHeader();
        AppendProjectsAndFolders(solution);
        return await Task.FromResult(SolutionFileContent.ToString());
    }
}