namespace Frank.SolutionManager.Tool;

public class MainMenu
{
    
    private readonly ActionChoiceCache _actionChoiceCache;

    public MainMenu(ActionChoiceCache actionChoiceCache)
    {
        _actionChoiceCache = actionChoiceCache;
    }

    public async Task RunAsync()
    {
        AnsiConsole
            .Write(new FigletText("Frank's Solution Manager")
                .Justify(Justify.Center)
                .Color(Color.Green)
            );

        while (true)
        {
            try
            {
                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What do you want to do?")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            MenuChoices.SetOutputDirectory,
                            MenuChoices.SetRepositoriesDirectory,
                            MenuChoices.ListAllRepositories,
                            MenuChoices.CheckoutDefaultBranchInAllRepositories,
                            MenuChoices.FetchAllRepositories,
                            MenuChoices.PullAllRepositories,
                            MenuChoices.Exit
                        }));

                var action = _actionChoiceCache.Get(selection);
                
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine($"[bold][green]{selection}[/][/]");
                await action.ExecuteAsync();
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
        }
    }
}