using Atom.Util;

namespace Frank.SolutionManager;

public static class SolutionFileHelper
{
    public static ISolution ParseSolution(FileInfo solutionFile)
    {
        if (!solutionFile.Exists || solutionFile.Extension != ".sln")
            throw new ArgumentException("The solution file does not exist or is not a .sln file.", nameof(solutionFile));
        var solutionFileData = SlnFile.ReadFromFile(solutionFile.FullName);
        
        var solution = new Solution(solutionFile)
        {
            Header = new SolutionFileHeader(solutionFileData.Header),
            GlobalSection = new SolutionGlobalSection(solutionFileData.GlobalSections),
        };
        
        foreach (var project in solutionFileData.Projects.Where(x => Guid.Parse(x.TypeId) == ProjectTypeIdentifiers.CSharp))
        {
            var projectFile = new FileInfo(solutionFileData.Browse().GetSolutionPath(project.ProjectId));
            var projectReference = new Project(projectFile, Guid.Parse(project.ProjectId));
            solution.AddProject(projectReference);
        }
        
        foreach (var project in solutionFileData.Projects.Where(x => Guid.Parse(x.TypeId) == ProjectTypeIdentifiers.SolutionFolder))
        {
            var folder = new Folder(project.Name, Guid.Parse(project.ProjectId));
            solution.AddFolder(folder);
        }

        return solution;
    }
    
    public static void WriteSolution(ISolution solution)
    {
        var solutionFileData = new SlnFileData()
        {
            Header = solution.Header,
            GlobalSections = solution.GlobalSection.ToList(),
        };
        
        foreach (var project in solution.Projects)
        {
            var projectData = new SlnFileProject
            {
                Name = project.Name,
                ProjectId = project.Id.ToString(),
                TypeId = ProjectTypeIdentifiers.CSharp.ToString(),
            };
            solutionFileData.Projects.Add(projectData);
        }
        
        foreach (var folder in solution.Folders)
        {
            var folderData = new SlnFileProject
            {
                Name = folder.Name,
                ProjectId = folder.Id.ToString(),
                TypeId = ProjectTypeIdentifiers.SolutionFolder.ToString(),
            };
            solutionFileData.Projects.Add(folderData);
        }
        
        SlnFile.WriteToFile(solutionFileData, solution.SolutionFile.FullName);
    }
}