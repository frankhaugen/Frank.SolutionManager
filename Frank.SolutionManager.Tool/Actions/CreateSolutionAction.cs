using System.Text;
using CliWrap;
using LibGit2Sharp;

namespace Frank.SolutionManager.Tool.Actions;

public class CreateSolutionAction(IGitService gitService, IOptions<AppSettings> options) : IAction
{
    /// <inheritdoc />
    public ActionName Name => ActionName.CreateSolution;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var solutionName = AnsiConsole.Ask<string>("Enter the solution name: ") + DateTime.Now.ToString("yyyyMMddHHmmss");
        var solutionDirectory = new DirectoryInfo(options.Value.RepositoriesRootPath ?? throw new InvalidOperationException("Repositories directory not set."));
        
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
        
        await DetectAndAddProjectsAsync(solutionDirectory, solutionFile);

        await Task.CompletedTask;
    }

    private async Task DetectAndAddProjectsAsync(DirectoryInfo solutionDirectory, FileInfo solutionFile)
    {
        var repositories = gitService.GetRepositories();
        var projects = repositories
            .SelectMany(GetProjectFiles)
            .DistinctBy(p => p.Name)
            .ToList();
        
        // Add projects to solution with dotnet sln add using CliWrap
        Table projectsTable = new Table();
        projectsTable.AddColumn("Project");
        projectsTable.AddColumn("Path");
        
        foreach (var project in projects)
        {
            var outputBuilder = new StringBuilder();
            
            var addProjectToSolutionCommand = Cli.Wrap("dotnet")
                    .WithArguments($"sln {solutionFile.FullName} add {project.FullName}")
                    .WithWorkingDirectory(solutionDirectory.FullName)
                    .WithValidation(CommandResultValidation.None)
                    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(outputBuilder))
                    .WithStandardErrorPipe(PipeTarget.ToStringBuilder(outputBuilder))
                ;
            
            var commandResult = await addProjectToSolutionCommand.ExecuteAsync();
            
            if (commandResult.ExitCode != 0)
            {
                AnsiConsole.MarkupLine($"Failed to add project '{project.FullName}' to solution '{solutionFile.FullName}'.");
                AnsiConsole.WriteLine(outputBuilder.ToString());
                continue;
            }
            
            projectsTable.AddRow(project.Name, project.FullName);
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