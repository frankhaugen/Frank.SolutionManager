namespace Frank.SolutionManager.Tool.Actions;

public class ListAllRepositoriesAction(IGitService gitService) : IAction
{
    public ActionName Name => ActionName.ListAllRepositories;

    public async Task ExecuteAsync()
    {
        var repositories = gitService.GetRepositories();
        
        foreach (var repository in repositories)
        {
            AnsiConsole.MarkupLine($"[bold]{repository.Info.WorkingDirectory}[/]");
        }
        
        await Task.CompletedTask;
    }
}