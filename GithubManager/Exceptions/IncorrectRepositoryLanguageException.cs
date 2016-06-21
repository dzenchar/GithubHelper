using System;

namespace GithubManager.Exceptions
{
    public class IncorrectRepositoryLanguageException : Exception
    {
        public IncorrectRepositoryLanguageException(string s) : base(s)
        {
        }
    }
}