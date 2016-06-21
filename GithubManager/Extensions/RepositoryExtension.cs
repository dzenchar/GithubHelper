using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GithubManager
{
    static class RepositoryExtension
    {

        private static string CSharpStringName = "C#";

        /// <summary>
        /// Check the language of the repository
        /// </summary>
        /// <param name="repo">It is the repository, which we are going to check.</param>
        /// <returns></returns>
        public static bool HasCorrectLanguage(this Repository repo)
        {
            return repo.Language == CSharpStringName;
        }

        /// <summary>
        /// The repository from GitHubClient without exceptions.
        /// </summary>
        /// <param name="client">It is a client, which contains the repositories</param>
        /// <param name="owner">It is a github login</param>
        /// <param name="name">The name of the repository.</param>
        /// <returns></returns>
        public static async Task<Repository> GetRepositoryOrDefault(this GitHubClient client, string owner, string name)
        {
            try
            {
                return await client.Repository.Get(owner, name);
            }
            catch (ApiException e)
            {
                return null;
            }
        }
    }
}
