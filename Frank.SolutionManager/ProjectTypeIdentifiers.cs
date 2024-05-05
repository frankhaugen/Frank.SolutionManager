namespace Frank.SolutionManager;

public static class ProjectTypeIdentifiers
{
    public static Guid CSharp => Guid.Parse("fae04ec0-301f-11d3-bf4b-00c04f79efbc");
    public static Guid SolutionFolder => Guid.Parse("2150e333-8fdc-42a3-9474-1a3956d46de8");
    
    public static ProjectType IdentifyProjectType(Guid projectTypeGuid)
    {
        if (projectTypeGuid == CSharp)
            return ProjectType.CSharp;
        if (projectTypeGuid == SolutionFolder)
            return ProjectType.SolutionFolder;
        
        throw new ArgumentOutOfRangeException(nameof(projectTypeGuid), projectTypeGuid, "Unknown project type.");
    }
}