using System.Text.Json;
using System.Text.Json.Serialization;
using Frank.SolutionManager;
using JetBrains.Annotations;
using Xunit.Abstractions;

namespace Frank.SolutionManager.Tests;

public class SolutionTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void ParseSolution()
    {
        // Arrange
        var solutionFile = new FileInfo(@"D:/repos/Frank.SolutionManager/Frank.SolutionManager.sln");
        
        // Act
        var result = SolutionFileHelper.ParseSolution(solutionFile);
        
        // Assert
        Assert.NotNull(result);
        
        outputHelper.WriteLine(result.Header.ToString());
        outputHelper.WriteLine(result.GlobalSection.ToString());
        outputHelper.WriteLine(result.SolutionFile.FullName);
        outputHelper.WriteJson(result, new JsonSerializerOptions()
        {
            Converters = { new JsonStringEnumConverter()},
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });
    }
}