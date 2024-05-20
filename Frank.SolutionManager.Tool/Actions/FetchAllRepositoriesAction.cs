using System.Diagnostics;
using LibGit2Sharp;

namespace Frank.SolutionManager.Tool.Actions;

public class FetchAllRepositoriesAction : IAction
{
    private readonly ISettings _settings;

    public FetchAllRepositoriesAction(ISettings settings)
    {
        _settings = settings;
    }

    public ActionName Name => ActionName.FetchAllRepositories;
    
    public async Task ExecuteAsync()
    {
        var repositoriesDirectory = new DirectoryInfo(_settings.GetValue(SettingKey.RepositoriesDirectory.ToString()) ?? string.Empty);
        
        var gitDirectories = repositoriesDirectory.GetDirectories(".git", SearchOption.AllDirectories);
        
        foreach (var gitDirectory in gitDirectories)
        {
            var repositoryDirectory = gitDirectory.Parent;
            var repositoryName = repositoryDirectory!.Name;
            
            AnsiConsole.MarkupLine($"Fetching repository '{repositoryName}'...");
            
            // use libgit2sharp
            var repository = new Repository(repositoryDirectory.FullName);
            Commands.Fetch(repository, "origin", Array.Empty<string>(), null, null);
                
        }
    }
}