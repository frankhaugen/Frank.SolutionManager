namespace Frank.SolutionManager;

public interface IContainConfigurations
{
    IEnumerable<PlatformSolutionConfiguration> Configurations { get; }
}