using Console = Spectre.Console.AnsiConsole;

namespace Frank.SolutionManager.Tool.Actions;

public abstract class BaseAction
{
    protected void Try(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception)
        {
            WriteException(exception);
        }
    }
    
    protected T Try<T>(Func<T> action)
    {
        try
        {
            return action();
        }
        catch (Exception exception)
        {
            WriteException(exception);
            return default;
        }
    }
    
    protected async Task TryAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception exception)
        {
            WriteException(exception);
        }
    }
    
    protected async Task<T> TryAsync<T>(Func<Task<T>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception exception)
        {
            WriteException(exception);
            return default;
        }
    }
    
    protected void Write(string message)
    {
        Console.WriteLine(message);
    }
    
    protected void WriteInfo(string message)
    {
        Console.MarkupLine($"[green]{message}[/]");
    }
    
    protected void WriteError(string message)
    {
        Console.MarkupLine($"[red]{message}[/]");
    }
    
    protected void WriteWarning(string message)
    {
        Console.MarkupLine($"[yellow]{message}[/]");
    }
    
    protected void WriteException(Exception exception)
    {
        Console.WriteException(exception);
    }
    
    protected void WriteException(Exception exception, string message)
    {
        Console.MarkupLine($"[red]{message}[/]");
        Console.WriteException(exception);
    }
}