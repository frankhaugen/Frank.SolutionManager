namespace Frank.SolutionManager.Tool.Components;

public class DirectorySelector : PathSelector, IPrompt<DirectoryInfo>
{
    public DirectoryInfo Show(IAnsiConsole console)
    {
        return GetDirectoryPathAsync(console).GetAwaiter().GetResult();
    }

    public async Task<DirectoryInfo> ShowAsync(IAnsiConsole console, CancellationToken cancellationToken)
    {
        return await GetDirectoryPathAsync(console);
    }

    private async Task<DirectoryInfo> GetDirectoryPathAsync(IAnsiConsole console)
    {
        var path = await GetPathAsync(console, false);
        return new DirectoryInfo(path);
    }
}