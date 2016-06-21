GithubHelper is an example web application, which interacts with GitHub API.

## Description

Application allows user to retrieve description of GitHub repository by owner's name and repository's name via GitHub API.

Solution contains three projects:
- GithubHelper. This project contains frontend part and ASP .NET WebApi service.
- GithubManager. Project contains business-logic layer of solution.
- GithubManager.Tests. Project contains unit tests of business logic.

## Architecture notes

Application uses Unity as DI container. There is one business layer service named GithubService, which implements IGithubService interface and registered in DI container.
Application uses MSTest as unit testing framework and has 100% code coverage.
For logging of errors and debug messages to log file used Apache log4net framework.
On frontend for responsive design used Bootstrap and AngularJs as MVVM framework.
For interaction with GitHub API used Octokit - GitHub API Client Library for .NET (https://github.com/octokit/octokit.net)
