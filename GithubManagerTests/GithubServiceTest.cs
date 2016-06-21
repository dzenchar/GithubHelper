using System.Threading.Tasks;
using GithubManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GithubManagerTests
{
    [TestClass]
    public class GithubServiceTest
    {
        [TestMethod]
        public async Task CorrectDescriptionGetting()
        {
            var c = new GithubService();
            var description = await c.GetDescription("octokit", "octokit.net");
            Assert.AreEqual(description, "A GitHub API client library for .NET ");
        }
    }
}
