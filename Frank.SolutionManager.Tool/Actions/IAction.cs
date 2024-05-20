namespace Frank.SolutionManager.Tool.Actions;

public interface IAction
{
    ActionName Name { get; }
    Task ExecuteAsync();
}