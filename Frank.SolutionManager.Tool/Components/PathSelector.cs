namespace Frank.SolutionManager.Tool.Components;

public abstract class PathSelector
    {
        protected readonly bool DisplayIcons = SelectorConstants.DisplayIcons;
        protected readonly bool CanCreateFolder = SelectorConstants.CanCreateFolder;
        protected readonly int PageSize = SelectorConstants.PageSize;
        protected readonly bool IsWindows = SelectorConstants.IsWindows;

        protected async Task<string> GetPathAsync(IAnsiConsole console, bool selectFile)
        {
            string currentFolder = SelectorConstants.DefaultFolder;

            while (true)
            {
                console.Clear();
                DisplayHeader(console, selectFile ? SelectorConstants.SelectFileText : SelectorConstants.SelectFolderText);
                DisplayCurrentPath(console, currentFolder);

                var entries = GetEntries(console, currentFolder, selectFile);

                var selected = console.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"[green]{(selectFile ? SelectorConstants.SelectFileText : SelectorConstants.SelectFolderText)}:[/]")
                        .PageSize(PageSize)
                        .MoreChoicesText($"[grey]{SelectorConstants.MoreChoicesText}[/]")
                        .AddChoices(entries.Keys)
                );

                var selectedPath = entries[selected];

                if (selectedPath == "/////")
                {
                    currentFolder = SelectDrive(console);
                }
                else if (selectedPath == "///new")
                {
                    CreateNewFolder(console, currentFolder);
                }
                else if (selectedPath == "///select")
                {
                    return currentFolder;
                }
                else if (Directory.Exists(selectedPath))
                {
                    currentFolder = selectedPath;
                }
                else
                {
                    return selectedPath;
                }
            }
        }

        private void DisplayHeader(IAnsiConsole console, string title)
        {
            var rule = new Rule($"[b][green]{title}[/][/]").Centered();
            console.Write(rule);
            console.WriteLine();
        }

        private void DisplayCurrentPath(IAnsiConsole console, string currentFolder)
        {
            console.Markup($"[b][Yellow]{SelectorConstants.ActualFolderText}: [/][/]");
            var path = new TextPath(currentFolder)
            {
                RootStyle = new Style(foreground: Color.Green),
                SeparatorStyle = new Style(foreground: Color.Green),
                StemStyle = new Style(foreground: Color.Blue),
                LeafStyle = new Style(foreground: Color.Yellow)
            };
            console.Write(path);
            console.WriteLine();
        }

        private Dictionary<string, string> GetEntries(IAnsiConsole console, string currentFolder, bool selectFile)
        {
            var entries = new Dictionary<string, string>();

            try
            {
                Directory.SetCurrentDirectory(currentFolder);
            }
            catch
            {
                currentFolder = SelectorConstants.DefaultFolder;
                Directory.SetCurrentDirectory(currentFolder);
            }

            AddSpecialEntries(entries, currentFolder, selectFile);

            var directoriesInFolder = Directory.GetDirectories(currentFolder);
            foreach (var dir in directoriesInFolder)
            {
                var folderName = Path.GetFileName(dir);
                entries.Add(DisplayIcons ? $":file_folder: {folderName}" : folderName, dir);
            }

            if (selectFile)
            {
                var filesInFolder = Directory.GetFiles(currentFolder);
                foreach (var file in filesInFolder)
                {
                    var fileName = Path.GetFileName(file);
                    entries.Add(DisplayIcons ? $":abacus: {fileName}" : fileName, file);
                }
            }

            return entries;
        }

        private void AddSpecialEntries(Dictionary<string, string> entries, string currentFolder, bool selectFile)
        {
            if (IsWindows)
            {
                entries.Add(DisplayIcons ? $"[green]:computer_disk: {SelectorConstants.SelectDriveText}[/]" : $"[green]{SelectorConstants.SelectDriveText}[/]", "/////");
            }

            var parentDir = Directory.GetParent(currentFolder)?.FullName;
            if (parentDir != null)
            {
                entries.Add(DisplayIcons ? $"[green]:upwards_button: {SelectorConstants.LevelUpText}[/]" : $"[green]{SelectorConstants.LevelUpText}[/]", parentDir);
            }

            if (!selectFile)
            {
                entries.Add(DisplayIcons ? $":ok_button: [green]{SelectorConstants.SelectActualText}[/]" : $"[green]{SelectorConstants.SelectActualText}[/]", "///select");
            }

            if (CanCreateFolder)
            {
                entries.Add(DisplayIcons ? $"[green]:plus: {SelectorConstants.CreateNewText}[/]" : $"[green]{SelectorConstants.CreateNewText}[/]", "///new");
            }
        }

        private string SelectDrive(IAnsiConsole console)
        {
            var drives = Directory.GetLogicalDrives();
            var result = new Dictionary<string, string>();
            foreach (var drive in drives)
            {
                result.Add(DisplayIcons ? $":computer_disk: {drive}" : drive, drive);
            }

            console.Clear();
            var rule = new Rule($"[b][green]{SelectorConstants.SelectDriveText}[/][/]").Centered();
            console.Write(rule);
            console.WriteLine();

            var selected = console.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]{SelectorConstants.SelectDriveText}:[/]")
                    .PageSize(PageSize)
                    .MoreChoicesText($"[grey]{SelectorConstants.MoreChoicesText}[/]")
                    .AddChoices(result.Keys)
            );

            return result[selected];
        }

        private void CreateNewFolder(IAnsiConsole console, string currentFolder)
        {
            var folderName = console.Ask<string>($"[blue]{SelectorConstants.CreateNewText}: [/]");
            if (!string.IsNullOrEmpty(folderName))
            {
                try
                {
                    var newFolder = Path.Combine(currentFolder, folderName);
                    Directory.CreateDirectory(newFolder);
                }
                catch (Exception ex)
                {
                    console.WriteLine($"[red]Error: [/]{ex.Message}");
                }
            }
        }
    }