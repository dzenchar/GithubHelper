using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubManager;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Github.GetAsync("octokit", "octokit.net");
            res = res;
        }
    }
}
