namespace Frank.SolutionManager;

public class Global
{
    public required IEnumerable<GlobalSection> Sections { get; init; }

    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        indentedStringBuilder.WriteLine("Global");
        indentedStringBuilder.IncreaseIndent();
        foreach (var section in Sections)
            indentedStringBuilder.WriteLine(section.ToString());
        indentedStringBuilder.DecreaseIndent();
        indentedStringBuilder.WriteLine("EndGlobal");
        return indentedStringBuilder.ToString();
    }
}