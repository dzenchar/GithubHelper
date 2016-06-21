using System.Threading.Tasks;
using GithubManager.Exceptions;
using GithubManager.Interface;
using log4net;
using Octokit;

namespace GithubManager.Services
{
    public class GithubService : IGithubService
    {
        private readonly ILog _logger;

        public GithubService(ILog logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Find the description of a C# repository.
        /// </summary>
        /// <param name="owner">Owner's login at the github</param>
        /// <param name="name">Name of the target repository</param>
        /// <returns></returns>
        public async Task<string> GetDescription(string owner, string name)
        {
            var client = CreateClient();
            var repo = await client.GetRepositoryOrDefault(owner, name, _logger).ConfigureAwait(false);
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
            {
                var message = $"Cannot load  {owner}/{name}";
                _logger.Debug(message);

                throw new RepositoryNotFoundException(message);
            }
            if (!repo.HasCorrectLanguage())
            {
                var message = $"{owner}/{name} is not C# application.";
                _logger.Debug(message);

                throw new IncorrectRepositoryLanguageException(message);
            }
        }
    }
}
