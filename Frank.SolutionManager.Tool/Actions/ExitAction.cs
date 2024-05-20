namespace Frank.SolutionManager.Tool.Actions;

public class ExitAction : IAction
{
    /// <inheritdoc />
    public ActionName Name => ActionName.Exit;

    /// <inheritdoc />
    public async Task ExecuteAsync()
    {
        AnsiConsole.MarkupLine("Goodbye!");
        Environment.Exit(0);
        await Task.CompletedTask;
    }
}