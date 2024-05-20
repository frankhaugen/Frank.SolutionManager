using Frank.SolutionManager.Tool.Actions;

namespace Frank.SolutionManager.Tool;

internal static class MenuChoices
{
    public const string SetOutputDirectory = "Set Output Directory";
    public const string SetRepositoriesDirectory = "Set Repositories Directory";
    public const string FetchAllRepositories = "Fetch all repositories";
    public const string PullAllRepositories = "Pull all repositories";
    public const string ListAllRepositories = "List all repositories";
    public const string CreateSolution = "Create solution";
    public const string Exit = "Exit";
    public const string CheckoutDefaultBranchInAllRepositories = "Checkout default branch in all repositories";

    public static IDictionary<ActionName, string> Choices = new Dictionary<ActionName, string>
    {
        {ActionName.SetOutputDirectory, SetOutputDirectory},
        {ActionName.SetRepositoriesDirectory, SetRepositoriesDirectory},
        {ActionName.FetchAllRepositories, FetchAllRepositories},
        {ActionName.PullAllRepositories, PullAllRepositories},
        {ActionName.ListAllRepositories, ListAllRepositories},
        {ActionName.CreateSolution, CreateSolution},
        {ActionName.CheckoutDefaultBranchInAllRepositories, CheckoutDefaultBranchInAllRepositories},
        {ActionName.Exit, Exit}
    };
}