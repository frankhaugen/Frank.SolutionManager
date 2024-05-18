// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

using System.Runtime.InteropServices;

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a class containing utility methods.
/// </summary>
internal static class Utility
{
    /// <summary>
    /// Gets a value indicating whether or not the current operating system is Windows.
    /// </summary>
    internal static readonly bool RunningOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    /// <summary>
    /// Gets a value indicating whether or not the current operating system is macOS.
    /// </summary>
    internal static readonly bool RunningOnMacOS = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    /// <summary>
    /// Writes the specified error to the console.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write the error to.</param>
    /// <param name="message">The message to write to <see cref="Console.Error" />.</param>
    /// <param name="args">An array of objects to write using <see cref="message" />.</param>
    internal static void WriteError(TextWriter writer, string message, params object[] args)
    {
        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.Red;

        writer.WriteLine(message, args);

        Console.ResetColor();
    }
}