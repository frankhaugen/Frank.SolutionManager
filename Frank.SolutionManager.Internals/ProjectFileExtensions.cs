// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a class that contains MSBuild project file extensions.
/// </summary>
internal static class ProjectFileExtensions
{
    /// <summary>
    /// Azure SDK projects (.ccproj).
    /// </summary>
    internal const string AzureSdk = ".ccproj";

    /// <summary>
    /// Azure Service Fabric projects (.sfproj).
    /// </summary>
    internal const string AzureServiceFabric = ".sfproj";

    /// <summary>
    /// Visual C++ projects (.vcxproj).
    /// </summary>
    internal const string Cpp = ".vcxproj";

    /// <summary>
    /// C# projects (.csproj).
    /// </summary>
    internal const string CSharp = ".csproj";

    /// <summary>
    /// F# projects (.fsproj).
    /// </summary>
    internal const string FSharp = ".fsproj";

    /// <summary>
    /// Visual J# projects (.vjsproj).
    /// </summary>
    internal const string JSharp = ".vjsproj";

    /// <summary>
    /// Legacy C++ projects (.vcproj).
    /// </summary>
    internal const string LegacyCpp = ".vcproj";

    /// <summary>
    /// Native projects (.nativeProj).
    /// </summary>
    internal const string Native = ".nativeProj";

    /// <summary>
    /// Node JS projects (.njsproj)
    /// </summary>
    internal const string NodeJS = ".njsproj";

    /// <summary>
    /// NuProj projects (.nuproj).
    /// </summary>
    internal const string NuProj = ".nuproj";

    /// <summary>
    /// Shared project items (.projitems)
    /// </summary>
    internal const string ProjItems = ".projitems";

    /// <summary>
    /// Scope SDK projects (.scopeproj).
    /// </summary>
    internal const string Scope = ".scopeproj";

    /// <summary>
    /// Shared project (.shproj)
    /// </summary>
    internal const string Shproj = ".shproj";

    /// <summary>
    /// SQL Server database projects (.sqlproj).
    /// </summary>
    internal const string SqlServerDb = ".sqlproj";

    /// <summary>
    /// Visual C++ Shared Project Items.
    /// </summary>
    internal const string VcxItems = ".vcxitems";

    /// <summary>
    /// Visual Basic projects (.vbproj).
    /// </summary>
    internal const string VisualBasic = ".vbproj";

    /// <summary>
    /// Windows Application Packaging projects (.wapproj).
    /// </summary>
    internal const string Wap = ".wapproj";

    /// <summary>
    /// WiX projects (.wixproj).
    /// </summary>
    internal const string Wix = ".wixproj";
}