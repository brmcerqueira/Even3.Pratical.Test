/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class DefaultController {
    constructor($scope: ng.IScope, $http: ng.IHttpService) {
        $scope.markings = [];
        $scope.startTime = 0;

        $http.get('api/marking/startTime').then(function (response) {
            $scope.startTime = response.data;
        }, function (reason) {
            alert(reason.data.exceptionMessage);
        });

        if (registration) {
            $scope.register = () => {
                $http.put('api/marking/' + registration, null).then(function () {
                    updateMarkings();
                    alert("registrado!");
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }

            var updateMarkings = function () {
                $http.get('api/marking/' + registration).then(function (response) {
                    $scope.markings = response.data;
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }

            updateMarkings();
        }
    }
}

main.controller('defaultController', ['$scope', '$http', DefaultController]);