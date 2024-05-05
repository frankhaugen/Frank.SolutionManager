namespace Frank.SolutionManager;

public interface IProject : INamed, IIdentifiable
{
    FileInfo ProjectFile { get; }
    
    IEnumerable<INugetPackage> NugetPackages { get; }
    
    IEnumerable<IProjectReference> ProjectReferences { get; }
    
    IProject AddNugetPackage(INugetPackage nugetPackage);
    
    IProject AddProjectReference(IProjectReference projectReference);
    
    IProject AddNugetPackages(IEnumerable<INugetPackage> nugetPackages);
    
    IProject AddProjectReferences(IEnumerable<IProjectReference> projectReferences);
}