using System.Threading.Tasks;
using GithubManager.Exceptions;
using GithubManager.Interface;
using Octokit;

namespace GithubManager.Services
{
    public class GithubService : IGithubService
    {
        /// <summary>
        /// Find the description of a C# repository.
        /// </summary>
        /// <param name="owner">Owner's login at the github</param>
        /// <param name="name">Name of the target repository</param>
        /// <returns></returns>
        public async Task<string> GetDescription(string owner, string name)
        {
            var client = CreateClient();
            var repo = await client.GetRepositoryOrDefault(owner, name).ConfigureAwait(false);
            ValidateRepository(repo, owner, name);
            string description = repo.Description;
            return description;
        }

        private const string AppNameForGithubClient = "TestGithubApp";

        /// <summary>
        /// Creates new GitHub client
        /// </summary>
        private GitHubClient CreateClient()
        {
            return new GitHubClient(new ProductHeaderValue(AppNameForGithubClient));
        }

        /// <summary>
        /// Validates repository for existence and correct language
        /// </summary>
        private void ValidateRepository(Repository repo, string owner, string name)
        {
            if (repo == null)
                throw new RepositoryNotFoundException($"Cannot load  {owner}/{name} ");
            if (!repo.HasCorrectLanguage())   
                throw new IncorrectRepositoryLanguageException($" {owner}/{name} is not C# application.");
        }
    }
}
