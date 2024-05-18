namespace Frank.SolutionManager;

public class NestedProjectsGlobalSection(IEnumerable<NestedProjects> nestedProjects)
{
    public IEnumerable<NestedProjects> NestedProjects { get; } = nestedProjects.ToArray();
    
    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        indentedStringBuilder.WriteLine($"GlobalSection({GlobalSectionName.NestedProjects}) = {Time.preSolution}");
        indentedStringBuilder.IncreaseIndent();
        foreach (var nestedProject in NestedProjects)
            indentedStringBuilder.WriteLine(nestedProject.ToString());
        indentedStringBuilder.DecreaseIndent();
        indentedStringBuilder.WriteLine($"EndGlobalSection");
        return indentedStringBuilder.ToString();
    }
}

public class NestedProjects
{
    public required Guid ParentProjectId { get; init; }
    public required Guid NestedProjectId { get; init; }
    
    public override string ToString() => $"    {{{ParentProjectId.ToString().ToUpper()}}} = {{{NestedProjectId.ToString().ToUpper()}}}";
}
