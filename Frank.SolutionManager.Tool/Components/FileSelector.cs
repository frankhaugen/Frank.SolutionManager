namespace Frank.SolutionManager.Tool.Components;

public class FileSelector : PathSelector, IPrompt<FileInfo>
{
    public FileInfo Show(IAnsiConsole console)
    {
        return GetFilePathAsync(console).GetAwaiter().GetResult();
    }

    public async Task<FileInfo> ShowAsync(IAnsiConsole console, CancellationToken cancellationToken)
    {
        return await GetFilePathAsync(console);
    }

    private async Task<FileInfo> GetFilePathAsync(IAnsiConsole console)
    {
        var path = await GetPathAsync(console, true);
        return new FileInfo(path);
    }
}