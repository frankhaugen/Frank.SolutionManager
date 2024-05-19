using Atom.Util;

namespace Frank.SolutionManager;

public class SolutionGlobalSection : List<SlnFileSection>
{
    public SolutionGlobalSection(IEnumerable<SlnFileSection> sections) : base(sections)
    {
    }
}