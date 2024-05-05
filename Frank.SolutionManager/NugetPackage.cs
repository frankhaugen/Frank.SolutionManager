namespace Frank.SolutionManager;

public class NugetPackage : INugetPackage
{
    public string PackageId { get; }
    public string Version { get; }
    
    public NugetPackage(string packageId, string version)
    {
        PackageId = packageId;
        Version = version;
    }
}