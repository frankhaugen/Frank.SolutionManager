using LibGit2Sharp;

namespace Frank.SolutionManager.Tool;

public interface IGitService
{
    IEnumerable<Repository> GetRepositories();
}