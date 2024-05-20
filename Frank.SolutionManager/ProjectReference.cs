namespace Frank.SolutionManager;

public class ProjectReference : IProjectReference
{
    public string RelativePath { get; }
    
    public ProjectReference(string relativePath)
    {
        RelativePath = relativePath;
    }
}