namespace Frank.SolutionManager;

public interface INugetPackage
{
    string PackageId { get; }
    string Version { get; }
}