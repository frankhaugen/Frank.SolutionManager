namespace Frank.SolutionManager;

public interface IProject : INamed, IIdentifiable
{
    FileInfo ProjectFile { get; }
    
    IEnumerable<INugetPackage> NugetPackages { get; }
    
    IEnumerable<IProjectReference> ProjectReferences { get; }
}