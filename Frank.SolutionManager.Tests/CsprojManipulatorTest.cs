using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Frank.SolutionManager;
using Frank.SolutionManager.Legacy.Parsers;
using JetBrains.Annotations;
using Xunit.Abstractions;

namespace Frank.SolutionManager.Tests;

public class CsprojManipulatorTests
{
    private readonly ITestOutputHelper _outputHelper;

    public CsprojManipulatorTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void LoadFile()
    {
        var file = new FileInfo(Path.Combine(GetCurrentDirectory().FullName, "TestProject.csproj"));
        var fileContent = 
                        """
                        <Project Sdk="Microsoft.NET.Sdk">
                        
                            <PropertyGroup>
                                <IsPackable>false</IsPackable>
                            </PropertyGroup>
                        
                            <ItemGroup>
                                <PackageReference Include="Microsoft.Build" ExcludeAssets="Runtime" Version="17.9.5" />
                                <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="8.0.0" />
                            </ItemGroup>
                            
                            <ItemGroup>
                                <InternalsVisibleTo Include="Frank.SolutionManager" />
                                <InternalsVisibleTo Include="Frank.SolutionManager.Tests" />
                            </ItemGroup>
                            
                            <ItemGroup>
                                <ProjectReference Include="..\Frank.SolutionManager\Frank.SolutionManager.csproj" />
                            </ItemGroup>
                            
                        </Project>
                        """;
        
        file.WriteAllText(fileContent);
        
        Assert.True(file.Exists);
        
        var csprojXDocument = CsprojManipulator.LoadProjectFile(file);
        _outputHelper.WriteLine(csprojXDocument.ToString());
        _outputHelper.WriteLine(new string('#', 50));
        
        var packageReferences = CsprojManipulator.GetNugetPackages(csprojXDocument);
        
        foreach (var packageReference in packageReferences)
        {
            _outputHelper.WriteLine(packageReference);
        }
        _outputHelper.WriteLine(new string('#', 50));
        
        var projectReferences = CsprojManipulator.GetProjectReferences(csprojXDocument);
        
        foreach (var projectReference in projectReferences)
        {
            _outputHelper.WriteLine(projectReference.RelativePath);
        }
        _outputHelper.WriteLine(new string('#', 50));
        
        file.Delete();
        Assert.False(file.Exists);
        
        // Add a new project reference and a new package reference
        var newProjectReference = new ProjectReference(@"..\Frank.SolutionManager.Tests\Frank.SolutionManager.Tests.csproj");
        var newPackageReference = new NugetPackage("Microsoft.Extensions.Logging", "8.0.0");
        
        CsprojManipulator.AddProjectReference(csprojXDocument, newProjectReference);
        CsprojManipulator.AddNugetPackage(csprojXDocument, newPackageReference);
        
        file.WriteAllText(csprojXDocument.ToString());
        file.Refresh();
        Assert.True(file.Exists);
        
        _outputHelper.WriteLine(file.ReadAllText());
        
        _outputHelper.WriteLine(new string('#', 50));
        var newCsprojXDocument = CsprojManipulator.LoadProjectFile(file);
        
        Assert.Equal(csprojXDocument.ToString(), newCsprojXDocument.ToString());
        
        _outputHelper.WriteLine(newCsprojXDocument.ToString());
        
        var project = new Project(file, Guid.NewGuid(), newCsprojXDocument);
        
        Assert.Equal(3, project.NugetPackages.Count());
        Assert.Equal(2, project.ProjectReferences.Count());
        
        
        var newProjectReference2 = new ProjectReference(@"..\Frank.SolutionManager.Tests\Frank.SolutionManager.Tests.csproj");
        var newPackageReference2 = new NugetPackage("Microsoft.Extensions.Logging", "8.0.0");
        
        project.AddProjectReference(newProjectReference2);
        project.AddNugetPackage(newPackageReference2);
        
        CsprojManipulator.Save(project);
        
        var newCsprojXDocument2 = CsprojManipulator.LoadProjectFile(file);
        
        Assert.Equal(project.NugetPackages.Count(), CsprojManipulator.GetNugetPackages(newCsprojXDocument2).Count());
        Assert.Equal(project.ProjectReferences.Count(), CsprojManipulator.GetProjectReferences(newCsprojXDocument2).Count());
        
        _outputHelper.WriteLine(newCsprojXDocument2.ToString());
    }
    
    
    
    private static DirectoryInfo GetCurrentDirectory() => new(AppContext.BaseDirectory);
}