/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class CollaboratorQueryController {
    constructor($scope: ng.IScope, $http: ng.IHttpService, $location: ng.ILocationService, keyService: KeyService) {
        $scope.source = [];

        $scope.edit = (id: number) => {
            keyService.key = id;
            $location.path("/collaboratorConfection");
        }

        $scope.remove = (id: number) => {
            if (confirm("Deseja excluir esse item?")) { 
                $http.delete('api/collaboratorConfection/' + id).then(function () {
                    alert("excluido!");
                    updateSource();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        }

        var updateSource = function () {
            $http.put('api/collaboratorQuery/', {}).then(function (response) {
                $scope.source = response.data;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        }

        updateSource();
    }
}

main.controller('collaboratorQueryController', ['$scope', '$http', '$location', "$keyService", CollaboratorQueryController]);