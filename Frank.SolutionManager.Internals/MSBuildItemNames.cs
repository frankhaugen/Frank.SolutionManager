// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a class that contains MSBuild item names.
/// </summary>
internal static class MSBuildItemNames
{
    /// <summary>
    /// The name of ProjectFile items.
    /// </summary>
    internal const string ProjectFile = nameof(ProjectFile);

    /// <summary>
    /// The name of ProjectReference items.
    /// </summary>
    internal const string ProjectReference = nameof(ProjectReference);

    /// <summary>
    /// The name of SlnGenCustomProjectTypeGuid items.
    /// </summary>
    internal const string SlnGenCustomProjectTypeGuid = nameof(SlnGenCustomProjectTypeGuid);

    /// <summary>
    /// The name of the SlnGenSolutionItem items.
    /// </summary>
    internal const string SlnGenSolutionItem = nameof(SlnGenSolutionItem);
}