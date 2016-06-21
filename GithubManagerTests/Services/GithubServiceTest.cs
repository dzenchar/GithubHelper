using System.Threading.Tasks;
using GithubManager.Exceptions;
using GithubManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GithubManagerTests.Services
{
    [TestClass]
    public class GithubServiceTest
    {
        [TestMethod]
        public async Task GetDescription_Success()
        {
            var c = new GithubService();
            var description = await c.GetDescription("octokit", "octokit.net");
            Assert.AreEqual(description, "A GitHub API client library for .NET ");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryNotFoundException))]
        public async Task GetDescription_Failed_RepositoryNotFound()
        {
            var c = new GithubService();
            var description = await c.GetDescription("Not exists owner", "Not exists repository");
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectRepositoryLanguageException))]
        public async Task GetDescription_Failed_IncorrectRepositoryLanguage()
        {
            var c = new GithubService();
            var description = await c.GetDescription("angular", "angular");
        }
    }
}
