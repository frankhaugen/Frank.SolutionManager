using Frank.SolutionManager.Internals;

namespace Frank.SolutionManager.Experimental;

public class SlnFileWrapper
{
    public void Foo()
    {
        var solution = new SlnFile();
        
        var folder = new SlnFolder("path");
        folder.Name = "name";
        
        var project = new SlnProject();
        
        solution.AddSolutionItems(folder);
    }
}