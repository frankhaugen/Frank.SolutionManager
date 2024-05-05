using System.Text.RegularExpressions;
using Frank.SolutionManager.Parsers;
using Xunit.Abstractions;

namespace Frank.SolutionManager.Tests.Parsers;

public class FileInfoExtensionsTest(ITestOutputHelper outputHelper)
{
    private readonly ITestOutputHelper _outputHelper = outputHelper;

    [Fact]
    public void TestFindAll_Projects()
    {
        var fileInfo = new FileInfo(Path.Combine("D:/repos/Frank.SolutionManager", "Frank.SolutionManager.sln"));
        var matches = fileInfo.FindAll("\nProject(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\")", "\nEndProject\n");
        
        foreach (var match in matches)
        {
            _outputHelper.WriteLine(match);
        }
        
        Assert.Equal(2, matches.Count());
    }
    [Fact]
    public void TestFindAll_SolutionFolder()
    {
        var fileInfo = new FileInfo(Path.Combine("D:/repos/Frank.SolutionManager", "Frank.SolutionManager.sln"));
        var matches = fileInfo.FindAll("\nProject(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\")", "\nEndProject\n");
        
        foreach (var match in matches)
        {
            _outputHelper.WriteLine(match);
        }
        
        Assert.Equal(1, matches.Count());
    }
    
    [Fact]
    public void TestFindAll_Global()
    {
        var fileInfo = new FileInfo(Path.Combine("D:/repos/Frank.SolutionManager", "Frank.SolutionManager.sln"));
        var matches = fileInfo.FindAll("\nGlobal", "\nEndGlobal");
        
        foreach (var match in matches)
        {
            _outputHelper.WriteLine(match);
        }
    }
    
    [Fact]
    public void TestReadAllText()
    {
        var fileInfo = new FileInfo(Path.Combine("D:/repos/Frank.SolutionManager", "Frank.SolutionManager.sln"));
        var content = fileInfo.ReadAllText();
        
        _outputHelper.WriteLine(content);
    }
}