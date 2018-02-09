/// <reference path="references.ts"/>

declare var registration: string;

function errorCallback(reason: any): void {
    alert(reason.data.exceptionMessage);
}

var main = angular.module('even3-pratical-test', ['ngRoute', 'ngSanitize', 'ds.clock', 'webcam']);

main.config(["$routeProvider", function ($routeProvider: ng.route.IRouteProvider) {
    $routeProvider.when("/", {
        templateUrl: "views/default.controller.html",
        controller: "defaultController"
    }).when("/collaboratorQuery", {
        templateUrl: "views/collaborator.query.controller.html",
        controller: "collaboratorQueryController"
    }).when("/shiftQuery", {
        templateUrl: "views/shift.query.controller.html",
        controller: "shiftQueryController"
    }).when("/collaboratorConfection", {
        templateUrl: "views/collaborator.confection.controller.html",
        controller: "collaboratorConfectionController"
    }).when("/shiftConfection", {
        templateUrl: "views/shift.confection.controller.html",
        controller: "shiftConfectionController"
    })
}]);