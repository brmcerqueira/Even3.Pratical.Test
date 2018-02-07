/// <reference path="references.ts"/>

var main = angular.module('even3-pratical-test', ['ngRoute', 'ngSanitize']);

main.config(["$routeProvider", function ($routeProvider: ng.route.IRouteProvider) {
    $routeProvider.when("/", {
        templateUrl: "views/default.controller.html",
        controller: "defaultController"
    });
}]);