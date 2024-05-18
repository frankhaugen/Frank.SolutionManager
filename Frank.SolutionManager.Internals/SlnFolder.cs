// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a folder in a Visual Studio solution file.
/// </summary>
internal sealed class SlnFolder
{
    /// <summary>
    /// The project type GUID for a folder.
    /// </summary>
    internal static readonly Guid FolderProjectTypeGuid = new (VisualStudioProjectTypeGuids.SolutionFolder);

    /// <summary>
    /// The project type GUID for a folder as a solution string.
    /// </summary>
    internal static readonly string FolderProjectTypeGuidString = FolderProjectTypeGuid.ToSolutionString();

    /// <summary>
    /// Initializes a new instance of the <see cref="SlnFolder"/> class.
    /// </summary>
    /// <param name="path">The full path of the folder.</param>
    internal SlnFolder(string path)
    {
            Name = Path.GetFileName(path);
            FullPath = path;
            FolderGuid = Guid.NewGuid();
        }

    /// <summary>
    /// Gets or sets the <see cref="Guid" /> of the folder.
    /// </summary>
    internal Guid FolderGuid { get; set; }

    /// <summary>
    /// Gets a <see cref="List{SlnFolder}" /> of child folders.
    /// </summary>
    internal List<SlnFolder> Folders { get; } = new ();

    /// <summary>
    /// Gets the full path of the folder.
    /// </summary>
    internal string FullPath { get; }

    /// <summary>
    /// Gets or sets the name of the folder.
    /// </summary>
    internal string Name { get; set; }

    /// <summary>
    /// Gets or sets the parent folder.
    /// </summary>
    internal SlnFolder Parent { get; set; }

    /// <summary>
    /// Gets a <see cref="List{SlnProject}" /> of projects in the folder.
    /// </summary>
    internal List<SlnProject> Projects { get; } = new ();

    /// <summary>
    /// Gets a <see cref="List{String}" /> of solution items in the folder.
    /// </summary>
    internal List<string> SolutionItems { get; } = new ();

    /// <summary>
    /// Gets the project type GUID of the folder.
    /// </summary>
    internal string ProjectTypeGuidString => FolderProjectTypeGuidString;
}