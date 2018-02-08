/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class DefaultController {
    constructor($scope: ng.IScope, $http: ng.IHttpService) {
        var collaboratorId = 1;

        $scope.markings = [];

        $scope.register = () => {
            $http.put('api/marking/' + collaboratorId, null).then(function () {
                updateMarkings();
                alert("registrado!");
            });
        }

        var updateMarkings = function () {
            $http.get('api/marking/' + collaboratorId).then(function (response) {
                $scope.markings = response.data;
            });
        }

        updateMarkings();
    }
}

main.controller('defaultController', ['$scope', '$http', DefaultController]);