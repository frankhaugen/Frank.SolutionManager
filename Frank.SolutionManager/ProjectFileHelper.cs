namespace Frank.SolutionManager;

public static class ProjectFileHelper
{
    public static IEnumerable<INugetPackage> GetNugetPackages(FileInfo csprojFile) => LoadProject(csprojFile).NugetPackages;
    
    public static IEnumerable<IProjectReference> GetProjectReferences(FileInfo csprojFile) => LoadProject(csprojFile).ProjectReferences;

    public static void AddProjectReference(FileInfo csprojFile, IProjectReference projectReference)
    {
        var project = LoadProject(csprojFile);
        
        
        
        SaveProject(project);
    }

    private static IProject LoadProject(FileInfo csprojFile)
    {
        if (csprojFile.Extension != ".csproj")
            throw new ArgumentException("The file is not a .csproj file.", nameof(csprojFile));
        
        if (!csprojFile.Exists)
            throw new FileNotFoundException($"The csproj file {csprojFile.FullName} does not exist.");
        
        return new Project(csprojFile, Guid.Empty);
    }

    private static void SaveProject(IProject project)
    {
        if (project.Id == Guid.Empty)
        {
            throw new ArgumentException("The project id is empty, the project has not been loaded correctly or is intended to be in-memory only.");
        }
        
        CsprojManipulator.Save(project);
    }
}