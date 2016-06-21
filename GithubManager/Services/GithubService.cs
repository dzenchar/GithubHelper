using System;
using System.Threading.Tasks;
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
            var client = NewClient();
            var repo = await client.GetRepositoryOrDefault(owner, name).ConfigureAwait(false);
            ValidateRepository(repo, owner, name);
            string description = repo.Description;
            return description;
        }

        private const string AppNameForGithubClient = "TestGithubApp";

        private GitHubClient NewClient() => new GitHubClient(new ProductHeaderValue(AppNameForGithubClient));

        private void ValidateRepository(Repository repo, string owner, string name)
        {
            if (repo == null)
                throw new Exception($"Cannot load  {owner}/{name} ");
            if (!repo.HasCorrectLanguage())   
                throw new Exception($" {owner}/{name} is not C# application.");
        }
    }
}
