namespace Frank.SolutionManager.Tool.Components;

public static class SelectorConstants
{
    public const string LevelUpText = "Go to upper level";
    public const string ActualFolderText = "Selected Folder";
    public const string MoreChoicesText = "Use arrows Up and Down to select";
    public const string CreateNewText = "Create new folder";
    public const string SelectFileText = "Select File";
    public const string SelectFolderText = "Select Folder";
    public const string SelectDriveText = "Select Drive";
    public const string SelectActualText = "Select Actual Folder";
    public const bool DisplayIcons = true;
    public const bool CanCreateFolder = true;
    public const int PageSize = 15;

    public static readonly bool IsWindows = Environment.OSVersion.Platform.ToString().Substring(0, 3).ToLower() == "win";
    public static readonly string DefaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
}