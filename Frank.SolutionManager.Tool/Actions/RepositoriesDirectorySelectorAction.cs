namespace Frank.SolutionManager.Tool.Actions;

internal class RepositoriesDirectorySelectorAction(ISettings settings) : IAction
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
                var repositoriesDirectoryPath = AnsiConsole.Ask<string>("Enter the repositories directory: ");
                repositoriesDirectory = new DirectoryInfo(repositoriesDirectoryPath);
                
                if (repositoriesDirectory.Exists) continue;
                repositoriesDirectory.Create();
                repositoriesDirectory.Refresh();
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }        
        }
        
        settings.SetValue(SettingKey.RepositoriesDirectory.ToString(), repositoriesDirectory.FullName);
        
        await Task.CompletedTask;
    }
}