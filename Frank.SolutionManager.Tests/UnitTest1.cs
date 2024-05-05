using Xunit.Abstractions;

namespace Frank.SolutionManager.Tests;

public class UnitTest1(ITestOutputHelper outputHelper)
{
    [Fact]
    public async Task TestSolutionBuilding()
    {
        var solutionDirectory = new DirectoryInfo("D:/repos/Frank.SolutionManager");
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, "Frank.SolutionManager.sln"));
        var solution = new Solution(solutionFile);
        
        outputHelper.WriteLine(await solution.GetSolutionFileContentAsync());
    }
    
    [Fact]
    public async Task TestSolutionWriting()
    {
        var solutionDirectory = new DirectoryInfo("D:/repos/Frank.SolutionManager");
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, "Frank.SolutionManager.sln"));
        var solution = new Solution(solutionFile);
        
        await solution.WriteSolutionFileAsync();
    }
    
    [Fact]
    public async Task TestSolutionReading()
    {
        var solutionDirectory = new DirectoryInfo("D:/repos/Frank.SolutionManager");
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, "Frank.SolutionManager.sln"));
        var solution = SolutionReader.ReadSolution(solutionFile);
        
        var content = await solution.GetSolutionFileContentAsync();
        outputHelper.WriteLine(content);
        
        Assert.Equal(content, await System.IO.File.ReadAllTextAsync(solutionFile.FullName));
    }
}