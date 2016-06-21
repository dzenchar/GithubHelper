app.service('GithubService', ['$http', function ($http) {
    return {
        GetDescription: function (owner, name) {
            return $http({
                method: 'GET',
                url: '/api/Github/' + owner + '/' + name
            });
        }
    };
}]);