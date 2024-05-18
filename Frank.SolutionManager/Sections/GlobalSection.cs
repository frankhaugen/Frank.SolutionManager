namespace Frank.SolutionManager;

public class GlobalSection
{
    public required GlobalSectionName Name { get; init; }
    public required Time Time { get; init; }
    
    public List<PlatformSolutionConfiguration> SolutionConfigurations { get; } = new List<PlatformSolutionConfiguration>();
    public List<PlatformProjectConfiguration> ProjectConfigurations { get; } = new List<PlatformProjectConfiguration>();

    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        indentedStringBuilder.WriteLine($"GlobalSection({Name}) = {Time}");
        indentedStringBuilder.IncreaseIndent();
        foreach (var solutionConfiguration in SolutionConfigurations)
            indentedStringBuilder.WriteLine(solutionConfiguration.ToString());
        foreach (var projectConfiguration in ProjectConfigurations)
            indentedStringBuilder.WriteLine(projectConfiguration.ToString());
        indentedStringBuilder.DecreaseIndent();
        indentedStringBuilder.WriteLine($"EndGlobalSection");
        return indentedStringBuilder.ToString();
    }
}