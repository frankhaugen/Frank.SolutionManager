using System.Text.RegularExpressions;

namespace Frank.SolutionManager.Parsers;

public static class ProjectsParser
{
    public static IEnumerable<IProject> ParseProjects(FileInfo solutionFileInfo)
    {
        var projects = new List<IProject>();
        
        var projectSections = solutionFileInfo.FindAll("Project(", "EndProject");
        return projects;
    }
}

public static class FileInfoExtensions
{
    public static string ReadAllText(this FileInfo fileInfo) => System.IO.File.ReadAllText(fileInfo.FullName);
    
    public static IEnumerable<string> ReadAllLines(this FileInfo fileInfo) => System.IO.File.ReadAllLines(fileInfo.FullName);
    
    public static void WriteAllText(this FileInfo fileInfo, string content) => System.IO.File.WriteAllText(fileInfo.FullName, content);
    
    public static void WriteAllLines(this FileInfo fileInfo, IEnumerable<string> lines) => System.IO.File.WriteAllLines(fileInfo.FullName, lines);
    
    public static void WriteEmpty(this FileInfo fileInfo) => System.IO.File.WriteAllText(fileInfo.FullName, string.Empty);
    
    public static string ReadUntilFirst(this FileInfo fileInfo, string until, int startIndex = 0)
    {
        var content = fileInfo.ReadAllText();
        var index = content.IndexOf(until, startIndex, StringComparison.Ordinal);
        return content.Substring(startIndex, index);
    }
    
    public static IEnumerable<string> FindAll(this FileInfo fileInfo, string pattern)
    {
        var content = fileInfo.ReadAllText();
        var matches = Regex.Matches(content, pattern);
        return matches.Select(m => m.Value);
    }
    
    public static IEnumerable<string> FindAll(this FileInfo fileInfo, string start, string end)
    {
        var content = fileInfo.ReadAllText().ReplaceLineEndings("\n");
        var output = new List<string>();
        
        var startIndex = 0;
        
        while (true)
        {
            var startMatch = content.IndexOf(start, startIndex, StringComparison.Ordinal);
            if (startMatch == -1)
                break;
            
            var endMatch = content.IndexOf(end, startMatch, StringComparison.Ordinal);
            if (endMatch == -1)
                break;
            
            var length = endMatch - startMatch + end.Length;
            output.Add(content.Substring(startMatch, length));
            
            startIndex = endMatch + end.Length;
        }
        
        return output;
    }
    
    public static void EnsureDirectoryExists(this FileInfo fileInfo) => fileInfo.Directory!.Create();
    
    public static async Task<string> ReadAllTextAsync(this FileInfo fileInfo) => await System.IO.File.ReadAllTextAsync(fileInfo.FullName);
    
    public static async Task<IEnumerable<string>> ReadAllLinesAsync(this FileInfo fileInfo) => await System.IO.File.ReadAllLinesAsync(fileInfo.FullName);
    
    public static async Task WriteAllTextAsync(this FileInfo fileInfo, string content) => await System.IO.File.WriteAllTextAsync(fileInfo.FullName, content);
    
    public static async Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> lines) => await System.IO.File.WriteAllLinesAsync(fileInfo.FullName, lines);

    public static void EnsureFileExists(this FileInfo fileInfo)
    {
        fileInfo.EnsureDirectoryExists();
        if (!fileInfo.Exists)
            fileInfo.Create().Close();
    }
}
    