using GithubManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GithubManagerTests
{
    [TestClass]
    public class GithubClientTests
    {
        [TestMethod]
        public async void CorrectDescriptionGetting()
        {
            var c = new GithubService();
            var description = await c.GetDescription("octokit", "octokit.net");
            Assert.AreEqual(description, "\"A GitHub API client library for .NET \"") ;
        }
    }
}
