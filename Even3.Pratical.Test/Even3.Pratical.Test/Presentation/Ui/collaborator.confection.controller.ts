/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class CollaboratorConfectionController {
    constructor($scope: ng.IScope, confectionService: ConfectionService) {
        confectionService.setup($scope, 'api/collaboratorConfection/',
            () => {
                $scope.name = null;
                $scope.email = null;
                $scope.registration = null;
            },
            (data) => {
                $scope.name = data.name;
                $scope.email = data.email;
                $scope.registration = data.registration;
            },
            () => {
                return {
                    name: $scope.name,
                    email: $scope.email,
                    registration: $scope.registration
                };
            });
    }
}

main.controller('collaboratorConfectionController', ['$scope', '$confectionService', CollaboratorConfectionController]);