// See https://aka.ms/new-console-template for more information

using Frank.SolutionManager.Tool;
using Frank.SolutionManager.Tool.Actions;
using Microsoft.Extensions.DependencyInjection;

await new ServiceCollection()
    .AddSingleton<IAction, RepositoriesDirectorySelectorAction>()
    .AddSingleton<IAction, SetOutputDirectoryAction>()
    .AddSingleton<IAction, CreateSolutionAction>()
    .AddSingleton<IAction, ExitAction>()
    .AddSingleton<IAction, FetchAllRepositoriesAction>()
    .AddSingleton<IAction, CheckoutDefaultBranchInAllRepositoriesAction>()
    .AddSingleton<IAction, ListAllRepositoriesAction>()
    .AddSingleton<IAction, PullAllRepositoriesAction>()
    .AddSingleton<IValueConverter, ValueConverter>()
    .AddSingleton<IGitService, GitService>()
    .AddSingleton<ISettings, Settings>()
    .AddSingleton<ActionChoiceCache>()
    .AddSingleton<MainMenu>()
    .BuildServiceProvider(new ServiceProviderOptions() { ValidateOnBuild = true, ValidateScopes = true })
    .GetRequiredService<MainMenu>()
    .RunAsync();