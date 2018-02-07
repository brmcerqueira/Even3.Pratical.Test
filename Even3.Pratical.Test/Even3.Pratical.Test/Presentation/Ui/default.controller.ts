/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class DefaultController {
    constructor($scope: ng.IScope) {
        $scope.message = 'Teste3';
    }
}

main.controller('defaultController', ['$scope', DefaultController]);