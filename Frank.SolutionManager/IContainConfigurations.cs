namespace Frank.SolutionManager;

public interface IContainConfigurations
{
    IEnumerable<PlatformConfiguration> Configurations { get; }
}