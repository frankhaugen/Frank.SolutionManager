using System.Diagnostics.CodeAnalysis;

namespace Frank.SolutionManager;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum Platform
{
    Any_CPU,
    x86,
    x64,
    ARM,
    ARM64
}