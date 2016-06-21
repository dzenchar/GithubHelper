using System;
using System.Threading.Tasks;
using System.Web.Http;
using GithubManager.Interface;
using log4net;

namespace GithubHelper.Controllers
{
    public class GithubController : ApiController
    {
        private readonly IGithubService _githubService;
        private readonly ILog _logger;

        public GithubController(IGithubService githubservice, ILog logger)
        {
            _githubService = githubservice;
            _logger = logger;
        }

        /// <summary>
        /// This method returns the description of a C# repository on Github
        /// </summary>
        /// <param name="owner">Owner's login at the github</param>
        /// <param name="name">Name of the target repository</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Github/{owner}/{*name}")]
        public async Task<string> GetDescription(string owner, string name)
        {
            _logger.Debug($"Called GithubController.GetDescription with {nameof(owner)} = {owner} and {nameof(name)} = {name}");

            #region Validation

            if (string.IsNullOrEmpty(owner))
            {
                throw new Exception($"{nameof(owner)} cannot be empty.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception($"{nameof(name)} cannot be empty.");
            }

            #endregion
            
            var description = await _githubService.GetDescription(owner, name);
            return description;
        }
    }
}
