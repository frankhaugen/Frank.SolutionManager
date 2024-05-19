namespace Frank.SolutionManager.Legacy.Sections;

public class FolderSection
{
    public required IFolder Folder { get; init; }

    /// <inheritdoc />
    public override string ToString()
    {
        using var indentedStringBuilder = new IndentedStringBuilder();
        // indentedStringBuilder.WriteLine($"Project(\"{{{ProjectTypeIdentifiers.SolutionFolder.ToString().ToUpper()}}}\") = \"{Folder.Name}\", \"{Folder.Name}\", \"{Folder.Id.ToString().ToUpper()}\"");
        indentedStringBuilder.IncreaseIndent();
        indentedStringBuilder.WriteLine($"ProjectSection(SolutionItems) = preProject");
        indentedStringBuilder.IncreaseIndent();
        // foreach (var file in Folder.Files)
        // {
        //     indentedStringBuilder.WriteLine($"{file.RelativePath} = {file.RelativePath}");
        // }
        indentedStringBuilder.DecreaseIndent();
        indentedStringBuilder.WriteLine("EndProjectSection");
        //
        // foreach (var folder in Folder.Folders)
        // {
        //     indentedStringBuilder.WriteLine(new FolderSection()
        //     {
        //         Folder = folder
        //     }.ToString());
        // }
        //
        // foreach (var project in Folder.Projects)
        // {
        //     indentedStringBuilder.WriteLine(new ProjectSection()
        //     {
        //         Project = project
        //     }.ToString());
        // }
        
        indentedStringBuilder.DecreaseIndent();
        indentedStringBuilder.WriteLine("EndProject");
        return indentedStringBuilder.ToString();
    }
}

public interface IFolder
{
}