using System;

namespace GithubManager.Exceptions
{
    public class RepositoryNotFoundException : Exception
    {
        public RepositoryNotFoundException(string s) : base(s)
        {
        }
    }
}