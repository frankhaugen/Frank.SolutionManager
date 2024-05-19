using Atom.Util;

namespace Frank.SolutionManager;

public class SolutionFileHeader : SlnFileHeader
{
    internal SolutionFileHeader() : this(Default())
    {
    }
    
    internal SolutionFileHeader(SlnFileHeader header)
    {
        FormatVersion = header.FormatVersion;
        CurrentVisualStudioVersion = header.CurrentVisualStudioVersion;
        MinimumVisualStudioVersion = header.MinimumVisualStudioVersion;
        FullVisualStudioVersion = header.FullVisualStudioVersion;
    }
}