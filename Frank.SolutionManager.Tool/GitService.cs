using LibGit2Sharp;

namespace Frank.SolutionManager.Tool;

public class GitService : IGitService
{
    private readonly DirectoryInfo _reposDirectory;
    private readonly IEnumerable<DirectoryInfo> _repositoryDirectories;
    private readonly IOptions<AppSettings> _options;

    public GitService(IOptions<AppSettings> options)
    {
        _options = options;
        _reposDirectory = new DirectoryInfo(_options.Value.RepositoriesRootPath ?? throw new InvalidOperationException("Repositories directory not set."));
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

    /// <inheritdoc />
    public void Fetch(Repository repository)
    {
        Commands.Fetch(repository, "origin", Array.Empty<string>(), null, null);
    }

    /// <inheritdoc />
    public void CheckoutDefaultBranch(Repository repository)
    {
        var remote = repository.Network.Remotes["origin"];
        
        if (remote is null)
        {
            AnsiConsole.MarkupLine($"[red]No remote found for repository '{repository.Info.WorkingDirectory}'[/]");
            return;
        }
        
        var defaultBranch = repository.Branches[repository.Head.FriendlyName];
        
        if (defaultBranch is null)
        {
            AnsiConsole.MarkupLine($"[red]No default branch found for repository '{repository.Info.WorkingDirectory}'[/]");
            return;
        }
        
        Commands.Checkout(repository, defaultBranch);
    }

    /// <inheritdoc />
    public void Pull(Repository repository)
    {
        Commands.Pull(repository, repository.Config.BuildSignature(DateTimeOffset.Now), new PullOptions());
    }

    public void FetchAllRepositories()
    {
        foreach (var repository in GetRepositories())
        {
            Commands.Fetch(repository, "origin", Array.Empty<string>(), null, null);
            AnsiConsole.MarkupLine($"[green]Fetched repository '{repository.Info.WorkingDirectory}'[/]");
        }
    }
    
    public void PullAllRepositories()
    {
        foreach (var repository in GetRepositories())
        {
            Commands.Pull(repository, repository.Config.BuildSignature(DateTimeOffset.Now), new PullOptions());
            
            AnsiConsole.MarkupLine($"[green]Pulled repository '{repository.Info.WorkingDirectory}'[/]");
        }
    }
    
    public void CheckoutDefaultBranchInAllRepositories()
    {
        foreach (var repository in GetRepositories())
        {
            var remote = repository.Network.Remotes["origin"];
            
            if (remote is null)
            {
                AnsiConsole.MarkupLine($"[red]No remote found for repository '{repository.Info.WorkingDirectory}'[/]");
                continue;
            }
            
            var defaultBranch = repository.Branches[repository.Head.FriendlyName];
            
            if (defaultBranch is null)
            {
                AnsiConsole.MarkupLine($"[red]No default branch found for repository '{repository.Info.WorkingDirectory}'[/]");
                continue;
            }
            
            Commands.Checkout(repository, defaultBranch);
        }
    }
}