// See https://aka.ms/new-console-template for more information

using Frank.SolutionManager.Tool;
using Frank.SolutionManager.Tool.Actions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());

builder.Configuration
    .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
    .AddEnvironmentVariables();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"))
    .AddSingleton<IAction, SetRepositoriesDirectoryAction>()
    .AddSingleton<IAction, CreateSolutionAction>()
    .AddSingleton<IAction, ExitAction>()
    .AddSingleton<IAction, FetchAllRepositoriesAction>()
    .AddSingleton<IAction, CheckoutDefaultBranchInAllRepositoriesAction>()
    .AddSingleton<IAction, ListAllRepositoriesAction>()
    .AddSingleton<IAction, PullAllRepositoriesAction>()
    .AddSingleton<IValueConverter, ValueConverter>()
    .AddSingleton<IGitService, GitService>()
    .AddSingleton<ActionChoiceCache>()
    .AddSingleton<MainMenu>();

var host = builder.Build();

var mainMenu = host.Services.GetRequiredService<MainMenu>();

await mainMenu.RunAsync();