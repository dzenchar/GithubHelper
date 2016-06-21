using System.Threading.Tasks;

namespace GithubManager.Interface
{
    public interface IGithubService
    {
        /// <summary>
        /// Find the description of a C# repository.
        /// </summary>
        /// <param name="owner">Owner's login at the github</param>
        /// <param name="name">Name of the target repository</param>
        /// <returns></returns>
        Task<string> GetDescription(string owner, string name);
    }
}