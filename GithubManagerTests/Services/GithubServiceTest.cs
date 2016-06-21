using System.Threading.Tasks;
using GithubManager.Exceptions;
using GithubManager.Interface;
using GithubManager.Services;
using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GithubManagerTests.Services
{
    [TestClass]
    public class GithubServiceTest
    {
        private UnityContainer _container;

        [TestInitialize]
        public void Setup()
        {
            _container = new UnityContainer();

            _container.RegisterType<IGithubService, GithubService>(new TransientLifetimeManager());

            BasicConfigurator.Configure();
            _container.RegisterInstance<ILog>(LogManager.GetLogger("Main application logger"));
        }

        [TestMethod]
        public async Task GetDescription_Success()
        {
            var service = _container.Resolve<IGithubService>();
            var description = await service.GetDescription("octokit", "octokit.net");
            Assert.AreEqual(description, "A GitHub API client library for .NET ");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryNotFoundException))]
        public async Task GetDescription_Failed_RepositoryNotFound()
        {
            var service = _container.Resolve<IGithubService>();
            var description = await service.GetDescription("Not exists owner", "Not exists repository");
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectRepositoryLanguageException))]
        public async Task GetDescription_Failed_IncorrectRepositoryLanguage()
        {
            var service = _container.Resolve<IGithubService>();
            var description = await service.GetDescription("angular", "angular");
        }
    }
}
