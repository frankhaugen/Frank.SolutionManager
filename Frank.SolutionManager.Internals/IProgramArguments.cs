namespace Frank.SolutionManager.Internals;

internal interface IProgramArguments
{
    /// <summary>
    /// Gets or sets a value indicating whether or not to disable building projects for configurations that are not supported by those projects
    /// </summary>
    string[] AlwaysBuild { get; set; }

    /// <summary>
    /// Gets or sets the binary logger arguments.
    /// </summary>
    (bool HasValue, string Arguments) BinaryLogger { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not folders containing a single item should be collapsed into their parent folder.
    /// </summary>
    string[] CollapseFolders { get; set; }

    /// <summary>
    /// Gets or sets the configurations to use when generating the solution.
    /// </summary>
    string[] Configuration { get; set; }

    /// <summary>
    /// Gets or sets the console logger arguments.
    /// </summary>
    (bool HasValue, string Arguments) ConsoleLoggerParameters { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the program should launch the debugger.
    /// </summary>
    bool Debug { get; set; }

    /// <summary>
    /// Gets or sets the full path to devenv.exe.
    /// </summary>
    string[] DevEnvFullPath { get; set; }

    /// <summary>
    /// Gets or sets exclude paths when searching for project files.
    /// </summary>
    string[] Exclude { get; set; }

    /// <summary>
    /// Gets or sets the file logger parameters.
    /// </summary>
    (bool HasValue, string Arguments) FileLoggerParameters { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether folder hierarchy should be generated in the solution.
    /// </summary>
    string[] Folders { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the main project should receive special treatment.
    /// </summary>
    bool IgnoreMainProject { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Visual Studio should be launched after the solution is generated.
    /// </summary>
    string[] LaunchVisualStudio { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Visual Studio should load projects.
    /// </summary>
    string[] LoadProjectsInVisualStudio { get; set; }

    /// <summary>
    /// Gets or sets the logger parameters.
    /// </summary>
    string[] Loggers { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the logo should be displayed.
    /// </summary>
    bool NoLogo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not warning messages should be suppressed..
    /// </summary>
    bool NoWarn { get; set; }

    /// <summary>
    /// Gets or sets the platforms to use when generating the solution.
    /// </summary>
    string[] Platform { get; set; }

    /// <summary>
    /// Gets or sets the full path to the projects to generate a solution for.
    /// </summary>
    string[] Projects { get; set; }

    /// <summary>
    /// Gets or sets the platforms to use when generating the solution.
    /// </summary>
    string[] Property { get; set; }

    /// <summary>
    /// Gets or sets the full path to the solution file to generate.
    /// </summary>
    string[] SolutionDirectoryFullPath { get; set; }

    /// <summary>
    /// Gets or sets the full path to the solution file to generate.
    /// </summary>
    string[] SolutionFileFullPath { get; set; }

    /// <summary>
    /// Gets or sets the verbosity to use.
    /// </summary>
    string[] Verbosity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not the version information should be displayed.
    /// </summary>
    bool Version { get; set; }

    /// <summary>
    /// Gets or sets the Visual Studio version to include in the solution file header.
    /// </summary>
    (bool HasValue, string Version) VisualStudioVersion { get; set; }

    /// <summary>
    /// Gets a value indicating whether or not to always include the project in the build even if it has no matching configuration
    /// </summary>
    /// <returns>true to always include the project in the build even if it has no matching configuration, otherwise false.</returns>
    bool EnableAlwaysBuild();

    /// <summary>
    /// Gets a value indicating whether or not folders should be collapsed.
    /// </summary>
    /// <returns>true if folders should be collapsed, otherwise false.</returns>
    bool EnableCollapseFolders();

    /// <summary>
    /// Gets a value indicating whether or not folders should be created in the solution.
    /// </summary>
    /// <param name="slnGenFoldersPropertyValue">The SlnGenFolders property value if it exists />.</param>
    /// <returns>true if folders should be used, otherwise false.</returns>
    bool EnableFolders(string slnGenFoldersPropertyValue);

    /// <summary>
    /// Gets the Configuration values based on what was specified as command-line arguments.
    /// </summary>
    /// <returns>An <see cref="IReadOnlyCollection{T}" /> containing the unique values for Configuration.</returns>
    IReadOnlyCollection<string> GetConfigurations();

    /// <summary>
    /// Gets the global properties to use when evaluating projects.
    /// </summary>
    /// <returns>An <see cref="IDictionary{String,String}" /> containing the global properties to use when evaluating projects.</returns>
    IDictionary<string, string> GetGlobalProperties();

    /// <summary>
    /// Gets the Platform values based on what was specified as command-line arguments.
    /// </summary>
    /// <returns>An <see cref="IReadOnlyCollection{T}" /> containing the unique values for Platform.</returns>
    IReadOnlyCollection<string> GetPlatforms();

    /// <summary>
    /// Gets a value indicating whether or not Visual Studio should be launched.
    /// </summary>
    /// <returns>True if Visual Studio should be launched, otherwise false.</returns>
    bool ShouldLaunchVisualStudio();

    /// <summary>
    /// Gets a value indicating whether or not projects should be loaded in Visual Studio.
    /// </summary>
    /// <returns>True if projects should be loaded in Visual Studio, otherwise false.</returns>
    bool ShouldLoadProjectsInVisualStudio();

}