namespace Frank.SolutionManager.Internals;

public class ProgramArguments : IProgramArguments
{
    /// <inheritdoc />
    public string[] AlwaysBuild { get; set; }

    /// <inheritdoc />
    public (bool HasValue, string Arguments) BinaryLogger { get; set; }

    /// <inheritdoc />
    public string[] CollapseFolders { get; set; }

    /// <inheritdoc />
    public string[] Configuration { get; set; }

    /// <inheritdoc />
    public (bool HasValue, string Arguments) ConsoleLoggerParameters { get; set; }

    /// <inheritdoc />
    public bool Debug { get; set; }

    /// <inheritdoc />
    public string[] DevEnvFullPath { get; set; }

    /// <inheritdoc />
    public string[] Exclude { get; set; }

    /// <inheritdoc />
    public (bool HasValue, string Arguments) FileLoggerParameters { get; set; }

    /// <inheritdoc />
    public string[] Folders { get; set; }

    /// <inheritdoc />
    public bool IgnoreMainProject { get; set; }

    /// <inheritdoc />
    public string[] LaunchVisualStudio { get; set; }

    /// <inheritdoc />
    public string[] LoadProjectsInVisualStudio { get; set; }

    /// <inheritdoc />
    public string[] Loggers { get; set; }

    /// <inheritdoc />
    public bool NoLogo { get; set; }

    /// <inheritdoc />
    public bool NoWarn { get; set; }

    /// <inheritdoc />
    public string[] Platform { get; set; }

    /// <inheritdoc />
    public string[] Projects { get; set; }

    /// <inheritdoc />
    public string[] Property { get; set; }

    /// <inheritdoc />
    public string[] SolutionDirectoryFullPath { get; set; }

    /// <inheritdoc />
    public string[] SolutionFileFullPath { get; set; }

    /// <inheritdoc />
    public string[] Verbosity { get; set; }

    /// <inheritdoc />
    public bool Version { get; set; }

    /// <inheritdoc />
    public (bool HasValue, string Version) VisualStudioVersion { get; set; }

    /// <inheritdoc />
    public bool EnableAlwaysBuild()
    {
        return false;
    }

    /// <inheritdoc />
    public bool EnableCollapseFolders()
    {
        return false;
    }

    /// <inheritdoc />
    public bool EnableFolders(string slnGenFoldersPropertyValue)
    {
        return false;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<string> GetConfigurations()
    {
        return null;
    }

    /// <inheritdoc />
    public IDictionary<string, string> GetGlobalProperties()
    {
        return null;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<string> GetPlatforms()
    {
        return null;
    }

    /// <inheritdoc />
    public bool ShouldLaunchVisualStudio()
    {
        return false;
    }

    /// <inheritdoc />
    public bool ShouldLoadProjectsInVisualStudio()
    {
        return false;
    }
}