namespace Frank.SolutionManager;

public class ProjectReference : IProjectReference
{
    public FileInfo ProjectReferenceFile { get; }
    public string RelativePath { get; }
    
    public ProjectReference(FileInfo projectReferenceFile, string relativePath)
    {
        ProjectReferenceFile = projectReferenceFile;
        RelativePath = relativePath;
    }
}