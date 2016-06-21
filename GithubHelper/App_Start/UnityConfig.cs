using Microsoft.Practices.Unity;
using System.Web.Http;
using GithubManager.Interface;
using GithubManager.Services;
using Unity.WebApi;

namespace GithubHelper
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IGithubService, GithubService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}