namespace Frank.SolutionManager;

public interface IFolder : INamed, IContainFolders, IContainProjects, IContainFiles, IIdentifiable, IFlatProjectsGetter
{
    IFolder AddFolder(IFolder folder);
    
    IFolder AddProject(IProject project);
    
    IFolder AddFile(IFile file);
    
    IFolder AddFolders(IEnumerable<IFolder> folders);
    
    IFolder AddProjects(IEnumerable<IProject> projects);
    
    IFolder AddFiles(IEnumerable<IFile> files);
}