// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a class that contains MSBuild property names.
/// </summary>
internal static class MSBuildPropertyNames
{
    /// <summary>
    /// Represents the BuildingProject property.
    /// </summary>
    internal const string BuildingProject = nameof(BuildingProject);

    /// <summary>
    /// Represents the DesignTimeBuild property.
    /// </summary>
    internal const string DesignTimeBuild = nameof(DesignTimeBuild);

    /// <summary>
    /// Represents the ExcludeRestorePackageImports property.
    /// </summary>
    internal const string ExcludeRestorePackageImports = nameof(ExcludeRestorePackageImports);

    /// <summary>
    /// Represents the IncludeInSolutionFile property.
    /// </summary>
    internal const string IncludeInSolutionFile = nameof(IncludeInSolutionFile);

    /// <summary>
    /// Represents the IsSlnGen property.
    /// </summary>
    internal const string IsSlnGen = nameof(IsSlnGen);

    /// <summary>
    /// Represents the IsTraversal property.
    /// </summary>
    internal const string IsTraversal = nameof(IsTraversal);

    /// <summary>
    /// Represents the IsTraversalProject property.
    /// </summary>
    internal const string IsTraversalProject = nameof(IsTraversalProject);

    /// <summary>
    /// Represents the ProjectGuid property.
    /// </summary>
    internal const string ProjectGuid = nameof(ProjectGuid);

    /// <summary>
    /// Represents the ProjectTypeGuid property.
    /// </summary>
    internal const string ProjectTypeGuid = nameof(ProjectTypeGuid);

    /// <summary>
    /// Represents the SlnGenBinLog property.
    /// </summary>
    internal const string SlnGenBinLog = nameof(SlnGenBinLog);

    /// <summary>
    /// Represents the SlnGenDebug property.
    /// </summary>
    internal const string SlnGenDebug = nameof(SlnGenDebug);

    /// <summary>
    /// Represents the SlnGenDevEnvFullPath property.
    /// </summary>
    internal const string SlnGenDevEnvFullPath = nameof(SlnGenDevEnvFullPath);

    /// <summary>
    /// Represents the SlnGenFolders property.
    /// </summary>
    internal const string SlnGenFolders = nameof(SlnGenFolders);

    /// <summary>
    /// Represents the SlnGenGlobalProperties property.
    /// </summary>
    internal const string SlnGenGlobalProperties = nameof(SlnGenGlobalProperties);

    /// <summary>
    /// Represents the SlnGenIsDeployable property.
    /// </summary>
    internal const string SlnGenIsDeployable = nameof(SlnGenIsDeployable);

    /// <summary>
    /// Represents the SlnGenLaunchVisualStudio property.
    /// </summary>
    internal const string SlnGenLaunchVisualStudio = nameof(SlnGenLaunchVisualStudio);

    /// <summary>
    /// Visual Studio version to add to the generated solution file.
    /// Specify "default" to use the same version selection logic launching does.
    /// </summary>
    internal const string SlnGenVSVersion = nameof(SlnGenVSVersion);

    /// <summary>
    /// Represents the SlnGenLoadProjects property.
    /// </summary>
    internal const string SlnGenLoadProjects = nameof(SlnGenLoadProjects);

    /// <summary>
    /// Represents the SlnGenProjectName property.
    /// </summary>
    internal const string SlnGenProjectName = nameof(SlnGenProjectName);

    /// <summary>
    /// Represents the SlnGenSolutionFileFullPath property.
    /// </summary>
    internal const string SlnGenSolutionFileFullPath = nameof(SlnGenSolutionFileFullPath);

    /// <summary>
    /// Represents the name of a solution folder to place the project in.
    /// </summary>
    internal const string SlnGenSolutionFolder = nameof(SlnGenSolutionFolder);

    /// <summary>
    /// Represents the UsingMicrosoftNETSdk property.
    /// </summary>
    internal const string UsingMicrosoftNETSdk = nameof(UsingMicrosoftNETSdk);
}