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
var DefaultController = /** @class */ (function () {
    function DefaultController($scope) {
        $scope.message = 'Teste3';
    }
    return DefaultController;
}());
main.controller('defaultController', ['$scope', DefaultController]);
//# sourceMappingURL=main-ui.js.map