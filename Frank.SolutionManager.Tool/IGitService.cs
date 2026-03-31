using LibGit2Sharp;

namespace Frank.SolutionManager.Tool;

public interface IGitService
{
    IEnumerable<Repository> GetRepositories();
    void Fetch(Repository repository);
    void CheckoutDefaultBranch(Repository repository);
    void Pull(Repository repository);
    
    void FetchAllRepositories();
    void CheckoutDefaultBranchInAllRepositories();
    void PullAllRepositories();
}