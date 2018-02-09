/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class DefaultController {
    constructor($scope: ng.IScope, $http: ng.IHttpService) {
        $scope.markings = [];
        $scope.startTime = 0;

        $scope.channel = {
            videoHeight: 400,
            videoWidth: 300,
            video: null
        };

        $http.get('api/marking/startTime').then(function (response) {
            $scope.startTime = response.data;
        }, errorCallback);

        if (registration) {
            $scope.register = () => {
                $http.put('api/marking/' + registration, null).then(function () {
                    updateMarkings();
                    alert("registrado!");
                }, errorCallback);
            }

            var updateMarkings = function () {
                $http.get('api/marking/' + registration).then(function (response) {
                    $scope.markings = response.data;
                }, errorCallback);
            }

            updateMarkings();
        }
    }
}

main.controller('defaultController', ['$scope', '$http', DefaultController]);