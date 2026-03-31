using LibGit2Sharp;

namespace Frank.SolutionManager.Tool.Actions;

public class CheckoutDefaultBranchInAllRepositoriesAction : BaseAction, IAction
{
    private readonly IGitService _gitService;

    public CheckoutDefaultBranchInAllRepositoriesAction(IGitService gitService)
    {
        _gitService = gitService;
    }

    public ActionName Name => ActionName.CheckoutDefaultBranchInAllRepositories;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        var repositories = _gitService.GetRepositories();
        
        foreach (var repository in repositories)
        {
            Try(() => _gitService.CheckoutDefaultBranch(repository));
        }
    }
}