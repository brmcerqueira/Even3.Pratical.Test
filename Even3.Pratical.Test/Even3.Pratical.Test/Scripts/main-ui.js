/// <reference path="../../Scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular-route.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular-sanitize.d.ts"/>
/// <reference path="../../Scripts/typings/jquery/jquery.d.ts"/> 
/// <reference path="references.ts"/>
var main = angular.module('even3-pratical-test', ['ngRoute', 'ngSanitize']);
main.config(["$routeProvider", function ($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "views/default.controller.html",
            controller: "defaultController"
        });
    }]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
function dayOfWeekFilter() {
    return function (value) {
        var result = "";
        switch (value) {
            case 0:
                result = "Domingo";
                break;
            case 1:
                result = "Segunda";
                break;
            case 2:
                result = "Terça";
                break;
            case 3:
                result = "Quarta";
                break;
            case 4:
                result = "Quinta";
                break;
            case 5:
                result = "Sexta";
                break;
            case 6:
                result = "Sábado";
                break;
        }
        return result;
    };
}
main.filter('dayOfWeek', dayOfWeekFilter);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var DefaultController = /** @class */ (function () {
    function DefaultController($scope, $http) {
        var collaboratorId = 1;
        $scope.markings = [];
        $scope.register = function () {
            $http.put('api/marking/' + collaboratorId, null).then(function () {
                updateMarkings();
                alert("registrado!");
            });
        };
        var updateMarkings = function () {
            $http.get('api/marking/' + collaboratorId).then(function (response) {
                $scope.markings = response.data;
            });
        };
        updateMarkings();
    }
    return DefaultController;
}());
main.controller('defaultController', ['$scope', '$http', DefaultController]);
//# sourceMappingURL=main-ui.js.map