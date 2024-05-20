namespace Frank.SolutionManager.Tool.Actions;

internal class SetOutputDirectoryAction(ISettings settings) : IAction
{
    /// <inheritdoc />
    public ActionName Name => ActionName.SetOutputDirectory;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        DirectoryInfo? outputDirectory = null;
        
        while (outputDirectory is null)
        {
            try
            {
                var outputDirectoryPath = AnsiConsole.Ask<string>("Enter the output directory: ");
                outputDirectory = new DirectoryInfo(outputDirectoryPath);
                
                if (outputDirectory.Exists) continue;
                outputDirectory.Create();
                outputDirectory.Refresh();
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }        
        }
        settings.SetValue(SettingKey.OutputDirectory.ToString(), outputDirectory.FullName);
        
        await Task.CompletedTask;
    }
}