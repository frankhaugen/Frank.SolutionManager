using Frank.SolutionManager.Legacy;
using Xunit.Abstractions;

namespace Frank.SolutionManager.Tests;

public class UnitTest1(ITestOutputHelper outputHelper)
{
    [Fact]
    public async Task TestSolutionAtomLib()
    {
        var solutionDirectory = new DirectoryInfo("D:/repos/Frank.SolutionManager");
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, "Frank.SolutionManager.sln"));
        var solution = Atom.Util.SlnFile.ReadFromFile(solutionFile.FullName);
        
        outputHelper.WriteLine(solution);
    }
}