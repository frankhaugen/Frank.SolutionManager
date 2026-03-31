using System.Diagnostics;

namespace Frank.SolutionManager.Tool.Actions;

public class PullAllRepositoriesAction : BaseAction, IAction
{
    private readonly IGitService _gitService;

    public PullAllRepositoriesAction(IGitService gitService)
    {
        _gitService = gitService;
    }

    /// <inheritdoc />
    public ActionName Name => ActionName.PullAllRepositories;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var repositories = _gitService.GetRepositories();
        
        foreach (var repository in repositories)
        {
            Try(() => _gitService.Pull(repository));
        }
        
        await Task.CompletedTask;
    }
}