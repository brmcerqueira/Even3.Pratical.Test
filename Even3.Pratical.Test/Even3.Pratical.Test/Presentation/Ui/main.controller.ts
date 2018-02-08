/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class MainController {
    constructor($scope: ng.IScope, $http: ng.IHttpService) {
        $scope.name = null;
        $http.get('api/collaborator/' + registration).then(function (response) {
            $scope.name = response.data;
        }, function (reason) {
            alert(reason.data.exceptionMessage);
        });
    }
}

main.controller('mainController', ['$scope', '$http', MainController]);