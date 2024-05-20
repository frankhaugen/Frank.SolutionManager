using System.Text;
using CliWrap;
using LibGit2Sharp;

namespace Frank.SolutionManager.Tool.Actions;

public class CreateSolutionAction(IGitService gitService, ISettings settings) : IAction
{
    /// <inheritdoc />
    public ActionName Name => ActionName.CreateSolution;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var solutionName = AnsiConsole.Ask<string>("Enter the solution name: ") + DateTime.Now.ToString("yyyyMMddHHmmss");
        var solutionDirectory = new DirectoryInfo(settings.GetValue(SettingKey.OutputDirectory.ToString()) ?? string.Empty);
        
        if (!solutionDirectory.Exists)
        {
            AnsiConsole.MarkupLine($"The output directory '{solutionDirectory.FullName}' does not exist.");
            return;
        }
        
        var solutionFilePath = Path.Combine(solutionDirectory.FullName, solutionName + ".sln");
        var solutionFile = new FileInfo(solutionFilePath);
        
        if (solutionFile.Exists)
        {
            AnsiConsole.MarkupLine($"The solution '{solutionName}' already exists at '{solutionFilePath}'.");
            return;
        }

        var createSolutionCommand = Cli.Wrap("dotnet")
            .WithArguments($"new sln -n {solutionName}")
            .WithWorkingDirectory(solutionDirectory.FullName)
            .WithValidation(CommandResultValidation.None);
        
        await createSolutionCommand.ExecuteAsync();
        
        await DetectAndAddProjectsAsSymlinksAsync(solutionDirectory, solutionFile);

        await Task.CompletedTask;
    }

    private async Task DetectAndAddProjectsAsSymlinksAsync(DirectoryInfo solutionDirectory, FileInfo solutionFile)
    {
        var symlinksDirectory = new DirectoryInfo(Path.Combine(solutionDirectory.FullName, Path.GetFileNameWithoutExtension(solutionFile.Name)));
        
        if (!symlinksDirectory.Exists)
        {
            symlinksDirectory.Create();
        }
        
        var repositories = gitService.GetRepositories();
        var projects = repositories
            .SelectMany(GetProjectFiles)
            .DistinctBy(p => p.Name)
            .ToList();
        
        // Create symbolic links
        Table projectsTable = new Table();
        projectsTable.AddColumn("Project");
        projectsTable.AddColumn("Path");
        projectsTable.AddColumn("Symbolic Link");
        projectsTable.AddColumn("Output");
        
        foreach (var project in projects)
        {
            var symbolicLink = new FileInfo(Path.Combine(symlinksDirectory.FullName, project.Name));
            
            symbolicLink.CreateAsSymbolicLink(project.FullName);
            AnsiConsole.MarkupLine($"Created symbolic link '{symbolicLink.FullName}' for project '{project.FullName}'.");
            
            // Add project to solution with dotnet sln add using CliWrap
            var outputBuilder = new StringBuilder();
            
            var addProjectToSolutionCommand = Cli.Wrap("dotnet")
                    .WithArguments($"sln {solutionFile.FullName} add {symbolicLink.FullName}")
                    .WithWorkingDirectory(solutionDirectory.FullName)
                    .WithValidation(CommandResultValidation.None)
                    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(outputBuilder))
                    .WithStandardErrorPipe(PipeTarget.ToStringBuilder(outputBuilder))
                ;
            
            var commandResult = await addProjectToSolutionCommand.ExecuteAsync();
            
            if (commandResult.ExitCode != 0)
            {
                AnsiConsole.MarkupLine($"Failed to add project '{symbolicLink.FullName}' to solution '{solutionFile.FullName}'.");
                AnsiConsole.WriteLine(outputBuilder.ToString());
                continue;
            }
            projectsTable.AddRow(project.Name, project.FullName, symbolicLink.FullName, outputBuilder.ToString());
        }
        
        AnsiConsole.Write(projectsTable);
    }

    private IEnumerable<FileInfo> GetProjectFiles(Repository repository)
    {
        var projectFiles = repository
            .Index
            .Select(e => e.Path)
            .Where(p => p.EndsWith(".csproj"))
            .Where(p => !p.Contains("bin") && !p.Contains("obj"))
            .Distinct()
            .Select(p => new FileInfo(Path.Combine(repository.Info.WorkingDirectory, p)))
            ;
        
        return projectFiles;
    }
}