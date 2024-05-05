using System.Text;

namespace Frank.SolutionManager;

public static class SolutionWriter
{
    private static readonly IIndentedStringBuilder SolutionFileContent = new IndentedStringBuilder();

    public static async Task WriteSolutionFileAsync(DirectoryInfo solutionDirectory, ISolution solution)
    {
        var content = await GetSolutionFileContentAsync(solution);
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, $"{solution.Name}.sln"));
        await using var writer = new StreamWriter(solutionFile.FullName, false, Encoding.UTF8);
        await writer.WriteAsync(content);
    }

    private static void AppendHeader()
    {
        SolutionFileContent.WriteLine("Microsoft Visual Studio Solution File, Format Version 12.00");
        SolutionFileContent.WriteLine("# Visual Studio Version 17");
        SolutionFileContent.WriteLine("VisualStudioVersion = 17.0.31903.59");
        SolutionFileContent.WriteLine("MinimumVisualStudioVersion = 10.0.40219.1");
    }

    private static void AppendProjectsAndFolders(ISolution solution)
    {
        foreach (var project in solution.Projects)
        {
            SolutionFileContent.WriteLine($"Project(\"{{{ProjectTypeIdentifiers.CSharp}}}\") = \"{project.Name}\", \"{Path.Combine(project.ProjectFile.Directory!.Name, project.ProjectFile.Name)}\", \"{{{project.Id}}}\"");
            SolutionFileContent.WriteLine("EndProject");
        }
        
        foreach (var folder in solution.Folders)
        {
            SolutionFileContent.WriteLine($"Project(\"{{{ProjectTypeIdentifiers.SolutionFolder}}}\") = \"{folder.Name}\", \"{folder.Name}\", \"{{{folder.Id}}}\"");

            SolutionFileContent.IncreaseIndent();
            foreach (var project in folder.Projects)
            {
                SolutionFileContent.WriteLine($"ProjectSection(ProjectDependencies) = postProject");
                SolutionFileContent.IncreaseIndent();
                SolutionFileContent.WriteLine($"{{{project.Id}}} = {{{project.Id}}}");
                SolutionFileContent.WriteLine("EndProjectSection");
            }
            
            SolutionFileContent.WriteLine("ProjectSection(SolutionItems) = preProject");
            foreach (var file in folder.Files)
            {
                SolutionFileContent.IncreaseIndent();
                SolutionFileContent.WriteLine($"{file.Name} = {file.Name}");
                SolutionFileContent.DecreaseIndent();
            }
            SolutionFileContent.WriteLine("EndProjectSection");
            SolutionFileContent.DecreaseIndent();
            
            SolutionFileContent.WriteLine("EndProject");
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
        SolutionFileContent.WriteLine("Global");
        SolutionFileContent.IncreaseIndent();
        SolutionFileContent.WriteLine("GlobalSection(SolutionConfigurationPlatforms) = preSolution");
        SolutionFileContent.IncreaseIndent();
        foreach (var configuration in solution.Configurations)
        {
            SolutionFileContent.WriteLine($"{configuration.Name} = {configuration.Name}");
        }
        SolutionFileContent.DecreaseIndent();
        SolutionFileContent.WriteLine("EndGlobalSection");
        SolutionFileContent.DecreaseIndent();
        SolutionFileContent.WriteLine("EndGlobal");
    }
}