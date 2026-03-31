namespace Frank.SolutionManager.Tool.Actions;

public class FetchAllRepositoriesAction : BaseAction, IAction
{
    private readonly IGitService _gitService;

    public FetchAllRepositoriesAction(IGitService gitService)
    {
        _gitService = gitService;
    }

    public ActionName Name => ActionName.FetchAllRepositories;
    
    public async Task ExecuteAsync()
    {
        var repositories = _gitService.GetRepositories();
        
        foreach (var repository in repositories)
        {
            Try(() => _gitService.Fetch(repository));
        }
        
        await Task.CompletedTask;
    }
}