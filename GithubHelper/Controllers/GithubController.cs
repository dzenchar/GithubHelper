﻿using GithubManager;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace GithubHelper.Controllers
{
    public class GithubController : ApiController
    {
        private Github githubClient;
        //will be injected by Ninject

        public GithubController(Github github)
        {
            githubClient = github;
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
            
            var description = await githubClient.GetDescription(owner, name);
            return description;
        }
    }
}