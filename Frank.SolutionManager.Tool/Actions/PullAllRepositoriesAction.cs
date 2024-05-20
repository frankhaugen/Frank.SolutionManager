using System.Diagnostics;

namespace Frank.SolutionManager.Tool.Actions;

public class PullAllRepositoriesAction : IAction
{
    private readonly ISettings _settings;

    public PullAllRepositoriesAction(ISettings settings)
    {
        _settings = settings;
    }

    /// <inheritdoc />
    public ActionName Name => ActionName.PullAllRepositories;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var repositoriesDirectory = new DirectoryInfo(_settings.GetValue(SettingKey.RepositoriesDirectory.ToString()));
        var repositories = repositoriesDirectory.GetDirectories();

        foreach (var repository in repositories)
        {
            var repositoryName = repository.Name;
            var repositoryPath = repository.FullName;

            AnsiConsole.MarkupLine($"Pulling repository [bold]{repositoryName}[/]...");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "pull",
                    WorkingDirectory = repositoryPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrWhiteSpace(output))
            {
                AnsiConsole.MarkupLine($"[green]{output}[/]");
            }

            if (!string.IsNullOrWhiteSpace(error))
            {
                AnsiConsole.MarkupLine($"[red]{error}[/]");
            }
        }

        await Task.CompletedTask;
    }
}