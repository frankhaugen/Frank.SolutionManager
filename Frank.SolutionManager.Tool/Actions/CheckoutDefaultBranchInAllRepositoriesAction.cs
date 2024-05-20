using LibGit2Sharp;

namespace Frank.SolutionManager.Tool.Actions;

public class CheckoutDefaultBranchInAllRepositoriesAction : IAction
{
    private readonly ISettings _settings;
    
    public CheckoutDefaultBranchInAllRepositoriesAction(ISettings settings)
    {
        _settings = settings;
    }
    
    public ActionName Name => ActionName.CheckoutDefaultBranchInAllRepositories;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var repositoriesDirectory = new DirectoryInfo(_settings.GetValue(SettingKey.RepositoriesDirectory.ToString()) ?? string.Empty);
        
        var gitDirectories = repositoriesDirectory.GetDirectories(".git", SearchOption.AllDirectories);
        
        foreach (var gitDirectory in gitDirectories)
        {
            try
            {
                CheckoutDefaultBranch(gitDirectory);
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
        }
    
    }

    private static void CheckoutDefaultBranch(DirectoryInfo gitDirectory)
    {
        var repositoryDirectory = gitDirectory.Parent;
        var repositoryName = repositoryDirectory!.Name;
            
        AnsiConsole.MarkupLine($"Checking out default branch in repository '{repositoryName}'...");
            
        var repository = new Repository(repositoryDirectory.FullName);
            
        var remote = repository.Network.Remotes["origin"];
            
        if (remote is null)
        {
            AnsiConsole.MarkupLine($"No remote found for repository '{repositoryName}'. Skipping...");
            return;
        }
            
        var defaultBranch = repository.Branches[repository.Head.FriendlyName];
            
        if (defaultBranch is null)
        {
            AnsiConsole.MarkupLine($"No default branch found for repository '{repositoryName}'. Skipping...");
            return;
        }
            
        Commands.Checkout(repository, defaultBranch);
            
        AnsiConsole.MarkupLine($"Checked out default branch '{defaultBranch.FriendlyName}' in repository '{repositoryName}'.");
    }
}