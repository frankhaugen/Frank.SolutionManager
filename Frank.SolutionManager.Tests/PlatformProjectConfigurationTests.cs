using Frank.SolutionManager.Legacy.Sections;
using Xunit.Abstractions;

namespace Frank.SolutionManager.Tests;

public class PlatformProjectConfigurationTests(ITestOutputHelper outputHelper)
{
    
    [Fact]
    public void TestToString()
    {
        var platformProjectConfiguration = new PlatformProjectConfiguration
        {
            ProjectGuid = Guid.Parse("22396815-37F6-4AA8-B8FF-B348CEA6B5E2"),
            Platform = Platform.Any_CPU,
            Configuration = Configuration.Debug
        };
        
        var expected = "{22396815-37F6-4AA8-B8FF-B348CEA6B5E2}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n" +
                            "{22396815-37F6-4AA8-B8FF-B348CEA6B5E2}.Debug|Any CPU.Build.0 = Debug|Any CPU\n";
        
        outputHelper.WriteLine(platformProjectConfiguration.ToString());
        Assert.Equal(expected, platformProjectConfiguration.ToString(), ignoreLineEndingDifferences: true, ignoreCase: true);
    }
}