/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class CollaboratorConfectionController {
    constructor($scope: ng.IScope, $http: ng.IHttpService, keyService: KeyService) {
        var url = 'api/collaboratorConfection/';

        var key = keyService.key
        keyService.key = null;

        var init = () => {
            $scope.name = null;
            $scope.email = null;
            $scope.registration = null;
        };

        init();

        if (key) {
            $http.get(url + key).then(function (response) {
                var data: any = response.data;
                $scope.name = data.name;
                $scope.email = data.email;
                $scope.registration = data.registration;
            });
        }
   
        $scope.save = () => {
            var entity = {
                name: $scope.name,
                email: $scope.email,
                registration: $scope.registration
            };

            if (key) {
                $http.post(url + key, entity).then(function () {
                    alert("salvo!");
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
            else {
                $http.put(url, entity).then(function () {
                    alert("salvo!");
                    init();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        }
    }
}

main.controller('collaboratorConfectionController', ['$scope', '$http', "$keyService", CollaboratorConfectionController]);