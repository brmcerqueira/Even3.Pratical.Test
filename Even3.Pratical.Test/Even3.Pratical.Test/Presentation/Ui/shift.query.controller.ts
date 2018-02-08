/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class ShiftQueryController {
    constructor($scope: ng.IScope, $http: ng.IHttpService, $location: ng.ILocationService, keyService: KeyService) {
        $scope.source = [];

        $scope.edit = (id: number) => {
            keyService.key = id;
            $location.path("/shiftConfection");
        }

        $scope.remove = (id: number) => {
            if (confirm("Deseja excluir esse item?")) { 
                $http.delete('api/shiftConfection/' + id).then(function () {
                    alert("excluido!");
                    updateSource();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        }

        var updateSource = function () {
            $http.put('api/shiftQuery/', {}).then(function (response) {
                $scope.source = response.data;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        }

        updateSource();
    }
}

main.controller('shiftQueryController', ['$scope', '$http', '$location', "$keyService", ShiftQueryController]);