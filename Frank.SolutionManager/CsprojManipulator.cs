using System.Xml.Linq;

namespace Frank.SolutionManager;

internal static class CsprojManipulator
{
    public static void Save(IProject project)
    {
        var projectFile = project.ProjectFile;
        var projectXml = LoadProjectFile(projectFile);
        var projectReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "ProjectReference");
        var packageReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "PackageReference");
        // foreach (var projectReference in projectReferences ?? Enumerable.Empty<XElement>())
        // {
        //     projectReference.Remove();
        // }
        // foreach (var packageReference in packageReferences ?? Enumerable.Empty<XElement>())
        // {
        //     packageReference.Remove();
        // }
        // foreach (var projectReference in project.ProjectReferences)
        // {
        //     var projectReferenceElement = new XElement("ProjectReference", new XAttribute("Include", projectReference.RelativePath));
        //     projectReferences.Last().AddAfterSelf(projectReferenceElement);
        // }
        // foreach (var packageReference in project.NugetPackages)
        // {
        //     var packageReferenceElement = new XElement("PackageReference", new XAttribute("Include", packageReference.PackageId), new XAttribute("Version", packageReference.Version));
        //     packageReferences.Last().AddAfterSelf(packageReferenceElement);
        // }
        SaveProjectFile(projectXml, projectFile);
    }
    
    public static IEnumerable<INugetPackage> GetNugetPackages(XDocument projectXml)
    {
        var packageReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "PackageReference");
        return packageReferences.Select(x => new NugetPackage(x.Attribute("Include")?.Value ?? string.Empty, x.Attribute("Version")?.Value ?? string.Empty));
    }
    
    public static IEnumerable<IProjectReference> GetProjectReferences(XDocument projectXml)
    {
        var projectReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "ProjectReference");
        return projectReferences.Select(x => new ProjectReference(x.Attribute("Include")?.Value ?? string.Empty));
    }
    
    public static void AddProjectReference(IProject project, IProjectReference projectReference)
    {
        var projectFile = project.ProjectFile;
        var projectXml = LoadProjectFile(projectFile);
        var projectReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "ProjectReference");
        var projectReferenceElement = new XElement("ProjectReference", new XAttribute("Include", projectReference.RelativePath));
        projectReferences.Last().AddAfterSelf(projectReferenceElement);
        SaveProjectFile(projectXml, projectFile);
    }
    
    public static void RemoveProjectReference(IProject project, IProjectReference projectReference)
    {
        var projectFile = project.ProjectFile;
        var projectXml = LoadProjectFile(projectFile);
        var projectReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "ProjectReference");
        var projectReferenceElement = projectReferences.FirstOrDefault(x => x.Attribute("Include")?.Value == projectReference.RelativePath);
        projectReferenceElement?.Remove();
        SaveProjectFile(projectXml, projectFile);
    }
    
    public static void AddPackageReference(IProject project, INugetPackage packageReference)
    {
        var projectFile = project.ProjectFile;
        var projectXml = LoadProjectFile(projectFile);
        var packageReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "PackageReference");
        var packageReferenceElement = new XElement("PackageReference", new XAttribute("Include", packageReference.PackageId), new XAttribute("Version", packageReference.Version));
        packageReferences.Last().AddAfterSelf(packageReferenceElement);
        SaveProjectFile(projectXml, projectFile);
    }
    
    public static void RemovePackageReference(IProject project, INugetPackage packageReference)
    {
        var projectFile = project.ProjectFile;
        var projectXml = LoadProjectFile(projectFile);
        var packageReferences = projectXml.Descendants().Where(x => x.Name.LocalName == "PackageReference");
        var packageReferenceElement = packageReferences.FirstOrDefault(x => x.Attribute("Include")?.Value == packageReference.PackageId);
        packageReferenceElement?.Remove();
        SaveProjectFile(projectXml, projectFile);
    }
    
    public static XDocument LoadProjectFile(FileSystemInfo projectFile) => XDocument.Load(projectFile.FullName);
    
    public static void SaveProjectFile(XDocument projectFile, FileSystemInfo projectFileInfo) => projectFile.Save(projectFileInfo.FullName);

    public static XDocument CreateNew()
    {
        var projectXml = new XDocument(
            new XElement("Project", new XAttribute("Sdk", "Microsoft.NET.Sdk"),
                new XElement("PropertyGroup",
                    new XElement("IsPackable", "false")),
                new XElement("ItemGroup",
                new XElement("ItemGroup"))));
        return projectXml;
    }

    public static void AddProjectReference(XDocument csprojXDocument, ProjectReference newProjectReference)
    {
        var projectReferences = csprojXDocument.Descendants().Where(x => x.Name.LocalName == "ProjectReference");
        var projectReferenceElement = new XElement("ProjectReference", new XAttribute("Include", newProjectReference.RelativePath));
        projectReferences.Last().AddAfterSelf(projectReferenceElement);
    }

    public static void AddNugetPackage(XDocument csprojXDocument, NugetPackage newPackageReference)
    {
        var packageReferences = csprojXDocument.Descendants().Where(x => x.Name.LocalName == "PackageReference");
        var packageReferenceElement = new XElement("PackageReference", new XAttribute("Include", newPackageReference.PackageId), new XAttribute("Version", newPackageReference.Version));
        packageReferences.Last().AddAfterSelf(packageReferenceElement);
    }
}