namespace Frank.SolutionManager;

public static class ProjectTypeIdentifiers
{
    public static Guid CSharp => Guid.Parse("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC");
    public static Guid SolutionFolder => Guid.Parse("2150E333-8FDC-42A3-9474-1A3956D46DE8");
    
    public static ProjectType IdentifyProjectType(Guid projectTypeGuid)
    {
        if (projectTypeGuid == CSharp)
            return ProjectType.CSharp;
        if (projectTypeGuid == SolutionFolder)
            return ProjectType.SolutionFolder;
        
        throw new ArgumentOutOfRangeException(nameof(projectTypeGuid), projectTypeGuid, "Unknown project type.");
    }
}