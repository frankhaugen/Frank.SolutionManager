using Atom.Util;

namespace Frank.SolutionManager;

public class SolutionBuilder(FileInfo solutionFile)
{
    private readonly string _solutionName = Path.GetFileNameWithoutExtension(solutionFile.Name);
    
    private readonly List<FileInfo> _projects = new();
    
    public SolutionBuilder WithProject(FileInfo project)
    {
        _projects.Add(project);
        return this;
    }

    public ISolution Build()
    {
        var solution = new Solution(solutionFile)
        {
            Header = new SolutionFileHeader(),
            GlobalSection = new SolutionGlobalSection(new List<SlnFileSection>())
        };
        foreach (var projectFile in _projects)
        {
            var project = new Project(projectFile);
            solution.AddProject(project);
        }
        return solution;
    }
}