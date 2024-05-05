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
        var solutionDirectory = new DirectoryInfo("D:/temp");
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, "Frank.SolutionManager.sln"));
        
        if (solutionFile.Exists)
            solutionFile.Delete();
        
        solutionFile.Refresh();
        solutionFile.Directory!.Create();
        solutionFile.Refresh();
        await System.IO.File.WriteAllTextAsync(solutionFile.FullName, string.Empty);
        
        var solution = new Solution(solutionFile);
        
        await solution.WriteSolutionFileAsync();
        
        var content = await solution.GetSolutionFileContentAsync();
        outputHelper.WriteLine(content);
        
        var expectedContent = await System.IO.File.ReadAllTextAsync(Path.Combine("D:/repos/Frank.SolutionManager", "Frank.SolutionManager.sln"));
        expectedContent = expectedContent.Replace("\r\n", "\n");
        
        var actualContent = await System.IO.File.ReadAllTextAsync(solutionFile.FullName);
        actualContent = actualContent.Replace("\r\n", "\n");
        Assert.Equal(expectedContent, actualContent);
    }
    
    [Fact]
    public async Task TestSolutionReading()
    {
        var solutionDirectory = new DirectoryInfo("D:/repos/Frank.SolutionManager");
        var solutionFile = new FileInfo(Path.Combine(solutionDirectory.FullName, "Frank.SolutionManager.sln"));
        var solution = SolutionParser.Parse(solutionFile);
        
        var content = await solution.GetSolutionFileContentAsync();
        outputHelper.WriteLine(content);
        outputHelper.WriteLine("################################################################################");
        
        var expectedContent = await System.IO.File.ReadAllTextAsync(solutionFile.FullName);
        expectedContent = expectedContent.Replace("\r\n", "\n").ReplaceLineEndings("\n");
        
        outputHelper.WriteLine(expectedContent);
        
        var actualContent = content.Replace("\r\n", "\n");
        
        Assert.Equal(expectedContent, actualContent, ignoreLineEndingDifferences: true, ignoreCase: true, ignoreWhiteSpaceDifferences: true, ignoreAllWhiteSpace: true);
    }
}