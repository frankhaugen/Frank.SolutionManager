using Frank.SolutionManager.Tool.Actions;

namespace Frank.SolutionManager.Tool;

public class ActionChoiceCache
{
    private readonly Dictionary<string, IAction> _actions;

    public ActionChoiceCache(IEnumerable<IAction> actions) => _actions = actions.ToDictionary(a => MenuChoices.Choices[a.Name], a => a);
    
    public IAction Get(string choice) => _actions[choice];
}