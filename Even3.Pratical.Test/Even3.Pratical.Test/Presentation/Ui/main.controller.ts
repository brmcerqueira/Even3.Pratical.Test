/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class MainController {
    constructor($scope: ng.IScope, $http: ng.IHttpService) {
        $scope.name = "Procurando...";
        var userNotFoundMessage = "Usuário não encontrado!";
        if (registration) {
            $http.get('api/collaborator/' + registration).then(function (response) {
                $scope.name = response.data ? response.data : userNotFoundMessage;
            }, errorCallback);
        }
        else {
            $scope.name = userNotFoundMessage;
        }
    }
}

main.controller('mainController', ['$scope', '$http', MainController]);