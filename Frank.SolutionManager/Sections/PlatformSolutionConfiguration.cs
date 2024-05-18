namespace Frank.SolutionManager;

public class PlatformSolutionConfiguration
{
    public required Platform Platform { get; init; }
    public required Configuration Configuration { get; init; }

    /// <inheritdoc />
    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        indentedStringBuilder.WriteLine($$"""{{Configuration}}|{{Platform.ToString().Replace("_", " ")}} = {{Configuration}}|{{Platform.ToString().Replace("_", " ")}}""");
        return indentedStringBuilder.ToString();
    }
}