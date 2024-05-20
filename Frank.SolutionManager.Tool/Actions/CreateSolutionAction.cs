using CliWrap;

namespace Frank.SolutionManager.Tool.Actions;

public class CreateSolutionAction(IGitService gitService, ISettings settings) : IAction
{
    /// <inheritdoc />
    public ActionName Name => ActionName.CreateSolution;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var solutionName = AnsiConsole.Ask<string>("Enter the solution name: ");
        var solutionDirectory = new DirectoryInfo(settings.GetValue(SettingKey.OutputDirectory.ToString()) ?? string.Empty);
        
        if (!solutionDirectory.Exists)
        {
            AnsiConsole.MarkupLine($"The output directory '{solutionDirectory.FullName}' does not exist.");
            return;
        }
        
        var solutionDirectoryPath = Path.Combine(solutionDirectory.FullName, solutionName + ".sln");
        
        if (File.Exists(solutionDirectoryPath))
        {
            AnsiConsole.MarkupLine($"The solution '{solutionName}' already exists at '{solutionDirectoryPath}'.");
            return;
        }
        
        var repositories = gitService.GetRepositories();

        var createSolutionCommand = Cli.Wrap("dotnet")
            .WithArguments($"new sln -n {solutionName}")
            .WithWorkingDirectory(solutionDirectory.FullName)
            .WithValidation(CommandResultValidation.None);
        
        await createSolutionCommand.ExecuteAsync();
        
        await Task.CompletedTask;
    }
}