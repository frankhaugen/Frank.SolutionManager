using System.Text;

namespace Frank.SolutionManager;

public static class SolutionWriter
{
    private static readonly IndentedStringBuilder SolutionFileContent = new IndentedStringBuilder();

    public static async Task WriteSolutionFileAsync(DirectoryInfo solutionDirectory, ISolution solution)
    {
        var content = await GetSolutionFileContentAsync(solution);
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, $"{solution.Name}.sln"));
        await using var writer = new StreamWriter(solutionFile.FullName, false, Encoding.UTF8);
        await writer.WriteAsync(content);
    }

    private static void AppendHeader()
    {
        // Microsoft Visual Studio Solution File, Format Version 12.00
        // # Visual Studio Version 17
        // VisualStudioVersion = 17.0.31903.59
        // MinimumVisualStudioVersion = 10.0.40219.1
        SolutionFileContent.WriteLine("Microsoft Visual Studio Solution File, Format Version 12.00");
        SolutionFileContent.WriteLine("# Visual Studio Version 17");
        SolutionFileContent.WriteLine("VisualStudioVersion = 17.0.31903.59");
        SolutionFileContent.WriteLine("MinimumVisualStudioVersion = 10.0.40219.1");
    }

    private static void AppendProjectsAndFolders(ISolution solution)
    {
        foreach (var project in solution.Projects)
        {
            SolutionFileContent.WriteLine(new ProjectSection()
            {
                Project = project
            }.ToString());
        }
        
        foreach (var folder in solution.Folders)
        {
            SolutionFileContent.WriteLine(new FolderSection()
            {
                Folder = folder
            }.ToString());
        }
    }

    public static async Task<string> GetSolutionFileContentAsync(ISolution solution)
    {
        SolutionFileContent.Clear();
        AppendHeader();
        AppendProjectsAndFolders(solution);
        AppendConfigurations(solution);
        return await Task.FromResult(SolutionFileContent.ToString().ReplaceLineEndings("\n"));
    }

    private static void AppendConfigurations(ISolution solution)
    {
        foreach (var configuration in solution.Configurations)
        {
            SolutionFileContent.WriteLine(configuration.ToString());
        }
    }
}