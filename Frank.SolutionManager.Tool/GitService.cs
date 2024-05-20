using LibGit2Sharp;

namespace Frank.SolutionManager.Tool;

public class GitService : IGitService
{
    private readonly DirectoryInfo _reposDirectory;
    private readonly IEnumerable<DirectoryInfo> _repositoryDirectories;
    private readonly ISettings _settings;

    public GitService(ISettings settings)
    {
        _settings = settings;
        _reposDirectory = new DirectoryInfo(settings.GetValue(SettingKey.RepositoriesDirectory.ToString()) ?? throw new InvalidOperationException("Repositories directory not set."));
        _repositoryDirectories = _reposDirectory.EnumerateDirectories(".git", SearchOption.AllDirectories).Select(d => d.Parent!);
    }
    
    public IEnumerable<Repository> GetRepositories()
    {
        var repositories = new List<Repository>();
        foreach (var directory in _repositoryDirectories)
        {
            try
            {
                var repository = new Repository(directory.FullName);
                repositories.Add(repository);
            }
            catch (RepositoryNotFoundException)
            {
                AnsiConsole.MarkupLine($"[red]No repository found at {directory.FullName}[/]");
            }
            catch (Exception e)
            {
                AnsiConsole.MarkupLine($"[red]Error opening repository at {directory.FullName}: {e.Message}[/]");
            }
        }

        return repositories;
    }
}