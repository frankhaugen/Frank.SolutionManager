namespace Frank.SolutionManager;

public class ProjectSection
{
    public required IProject Project { get; init; }
    
    public IEnumerable<PlatformProjectConfiguration> GetPlatformProjectConfigurations()
    {
        yield return new PlatformProjectConfiguration
        {
            ProjectGuid = Project.Id,
            Platform = Platform.Any_CPU,
            Configuration = Configuration.Debug
        };
        yield return new PlatformProjectConfiguration
        {
            ProjectGuid = Project.Id,
            Platform = Platform.Any_CPU,
            Configuration = Configuration.Release
        };
    }
    
    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        indentedStringBuilder.WriteLine($"Project(\"{{{ProjectTypeIdentifiers.CSharp.ToString().ToUpper()}}}\") = \"{Project.Name}\", \"{Project.GetRelativePath()}\", \"{{{Project.Id.ToString().ToUpper()}}}\"");
        indentedStringBuilder.Write("EndProject");
        return indentedStringBuilder.ToString();
    }
}