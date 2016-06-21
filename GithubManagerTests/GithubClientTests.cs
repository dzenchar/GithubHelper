using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GithubManager;

namespace GithubManagerTests
{
    [TestClass]
    public class GithubClientTests
    {
        [TestMethod]
        public async void CorrectDescriptionGetting()
        {
            var c = new Github();
            var description = await c.GetDescription("octokit", "octokit.net");
            Assert.AreEqual(description, "\"A GitHub API client library for .NET \"") ;
        }
    }
}
