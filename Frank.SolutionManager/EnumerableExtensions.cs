namespace Frank.SolutionManager;

public static class EnumerableExtensions
{
    public static GlobalSection GetGlobalSection(this IEnumerable<IProject> projects)
    {
        projects = projects.ToArray();
        var section = new GlobalSection()
        {
            Name = GlobalSectionName.ProjectConfigurationPlatforms,
            Time = Time.preSolution,
            ProjectConfigurations = {},
        };
        
        section.ProjectConfigurations.AddRange(projects.Select(p => new PlatformProjectConfiguration()
        {
            Configuration = Configuration.Debug,
            Platform = Platform.Any_CPU,
            ProjectGuid = p.Id,
        }));
        
        section.ProjectConfigurations.AddRange(projects.Select(p => new PlatformProjectConfiguration()
        {
            Configuration = Configuration.Release,
            Platform = Platform.Any_CPU,
            ProjectGuid = p.Id,
        }));
        
        return section;
    }
    
    public static NestedProjectsGlobalSection GetGlobalSection(this IEnumerable<IFolder> folders)
    {
        folders = folders.ToArray();
        var nestedProjects = folders.SelectMany(f => f.Projects.Select(p => new NestedProjects()
        {
            ParentProjectId = f.Id,
            NestedProjectId = p.Id,
        }));
        var section = new NestedProjectsGlobalSection(nestedProjects);
        
        return section;
    }
}