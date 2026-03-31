using Frank.SolutionManager.Tool.Components;

namespace Frank.SolutionManager.Tool.Actions;

internal class SetRepositoriesDirectoryAction(IOptions<AppSettings> options) : IAction
{
    /// <inheritdoc />
    public ActionName Name => ActionName.SetRepositoriesDirectory;

    public async Task ExecuteAsync()
    {
        DirectoryInfo? repositoriesDirectory = null;
        
        while (repositoriesDirectory is null)
        {
            try
            {
                repositoriesDirectory = AnsiConsole.Prompt(new DirectorySelector());
                
                if (repositoriesDirectory.Exists) continue;
                repositoriesDirectory.Create();
                repositoriesDirectory.Refresh();
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }        
        }
        
        options.Value.RepositoriesRootPath = repositoriesDirectory.FullName;
        
        await Task.CompletedTask;
    }
}