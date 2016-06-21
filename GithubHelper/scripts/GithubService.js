(function () {

    var GithubService = function ($http) {
        return {
            GetDescription: function (owner, name) {
                return $http({
                    method: "GET",
                    url: "/api/Github/" + owner + "/" + name
                });
            }
        };
    }

    app.factory("GithubService", GithubService);
})();