namespace Frank.SolutionManager;

public class PlatformConfiguration(string name, string platform, string configuration)
{
    public string Name { get; init; } = name;
    public string Platform { get; init; } = platform;
    public string Configuration { get; init; } = configuration;
}