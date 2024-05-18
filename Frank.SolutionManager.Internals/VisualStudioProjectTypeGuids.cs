﻿// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a class that contains Visual Studio project type GUIDs.
/// </summary>
internal static class VisualStudioProjectTypeGuids
{
    /// <summary>
    /// Azure SDK project (.ccproj).
    /// </summary>
    internal const string AzureSdk = "CC5FD16D-436D-48AD-A40C-5A424C6E3E79";

    /// <summary>
    /// Azure Service Fabric projects (.sfproj).
    /// </summary>
    internal const string AzureServiceFabric = "A07B5EB6-E848-4116-A8D0-A826331D98C6";

    /// <summary>
    /// Visual C++ projects (.vcxproj).
    /// </summary>
    internal const string Cpp = "8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942";

    /// <summary>
    /// F# projects (.fsproj).
    /// </summary>
    internal const string FSharp = "F2A71F9B-5D33-465A-A702-920D77279786";

    /// <summary>
    /// Visual J# projects (.vjsproj).
    /// </summary>
    internal const string JSharp = "E6FDF86B-F3D1-11D4-8576-0002A516ECE8";

    /// <summary>
    /// Legacy C# projects (.csproj).
    /// </summary>
    internal const string LegacyCSharpProject = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC";

    /// <summary>
    /// Legacy Visual Basic projects (.vbproj).
    /// </summary>
    internal const string LegacyVisualBasicProject = "F184B08F-C81C-45F6-A57F-5ABD9991F28F";

    /// <summary>
    /// Microsoft.NET.Sdk C# projects (.csproj).
    /// </summary>
    internal const string NetSdkCSharpProject = "9A19103F-16F7-4668-BE54-9A1E7A4F7556";

    /// <summary>
    /// Microsoft.NET.Sdk Visual Basic projects (.vbproj).
    /// </summary>
    internal const string NetSdkVisualBasicProject = "778DAE3C-4631-46EA-AA77-85C1314464D9";

    /// <summary>
    /// Node JS projects (.njsproj)
    /// </summary>
    internal const string NodeJSProject = "9092AA53-FB77-4645-B42D-1CCCA6BD08BD";

    /// <summary>
    /// NuProj projects (.nuproj).
    /// </summary>
    internal const string NuProj = "FF286327-C783-4F7A-AB73-9BCBAD0D4460";

    /// <summary>
    /// Scope SDK projects (.scopeproj).
    /// </summary>
    internal const string ScopeProject = "202899A3-C531-4771-9089-0213D66978AE";

    /// <summary>
    /// Shared projects (.shproj)
    /// </summary>
    internal const string SharedProject = "D954291E-2A0B-460D-934E-DC6B0785DB48";

    /// <summary>
    /// Visual Studio solution folder.
    /// </summary>
    internal const string SolutionFolder = "2150E333-8FDC-42A3-9474-1A3956D46DE8";

    /// <summary>
    /// SQL Server database projects (.sqlproj).
    /// </summary>
    internal const string SqlServerDbProject = "00D1A9C2-B5F0-4AF3-8072-F6C62B433612";

    /// <summary>
    /// Windows Application Packaging projects (.wapproj).
    /// </summary>
    internal const string WapProject = "C7167F0D-BC9F-4E6E-AFE1-012C56B48DB5";

    /// <summary>
    /// WiX projects (.wixproj).
    /// </summary>
    internal const string Wix = "930C7802-8A8C-48F9-8165-68863BCCD9DD";
}