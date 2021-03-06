﻿app.controller('MainController', ['$scope', 'GithubService', function ($scope, githubService) {

    $scope.owner = 'octokit';
    $scope.repo = 'octokit.net';

    $scope.buttonDisable = false;

    $scope.checkBtn_Click = function () {

        if (!$scope.owner) {
            alert('owner cannot be empty');
            return;
        }
        if (!$scope.repo) {
            alert('repo cannot be empty');
            return;
        }

        $scope.buttonDisable = true;

        githubService.GetDescription($scope.owner, $scope.repo)
            .then(
                function(response) {
                    $scope.success = response.data;
                    $scope.buttonDisable = false;
                    $scope.hasErrors = false;
                }, function(response) {
                    $scope.hasErrors = true;
                    $scope.error = response.data.ExceptionMessage;
                    $scope.buttonDisable = false;
                });
    }
}]);