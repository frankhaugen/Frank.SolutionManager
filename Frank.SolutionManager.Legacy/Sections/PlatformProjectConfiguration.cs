namespace Frank.SolutionManager.Legacy.Sections;

public class PlatformProjectConfiguration
{
    public required Guid ProjectGuid { get; init; }
    public required Platform Platform { get; init; }
    public required Configuration Configuration { get; init; }

    /// <inheritdoc />
    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        indentedStringBuilder.WriteLine($$"""{{{ProjectGuid}}}.{{Configuration}}|{{Platform.ToString().Replace("_", " ")}}.ActiveCfg = {{Configuration}}|{{Platform.ToString().Replace("_", " ")}}""");
        indentedStringBuilder.WriteLine($$"""{{{ProjectGuid}}}.{{Configuration}}|{{Platform.ToString().Replace("_", " ")}}.Build.0 = {{Configuration}}|{{Platform.ToString().Replace("_", " ")}}""");
        return indentedStringBuilder.ToString();
    }
}