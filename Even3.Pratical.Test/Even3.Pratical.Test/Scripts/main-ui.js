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
        });
    }]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var MainController = /** @class */ (function () {
    function MainController($scope, $http) {
        $scope.name = null;
        $http.get('api/collaborator/' + registration).then(function (response) {
            $scope.name = response.data;
        }, function (reason) {
            alert(reason.data.exceptionMessage);
        });
    }
    return MainController;
}());
main.controller('mainController', ['$scope', '$http', MainController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var ShiftConfectionController = /** @class */ (function () {
    function ShiftConfectionController($scope, $http, keyService) {
        var url = 'api/shiftConfection/';
        var key = keyService.key;
        keyService.key = null;
        var init = function () {
            $scope.dayOfWeek = "0";
            $scope.input = null;
            $scope.output = null;
            $scope.interval = null;
        };
        var parseFromTimeSpan = function (timeSpan) {
            return new Date('01 01 1970 ' + timeSpan);
        };
        var parseToTimeSpan = function (date) {
            return date.getHours() + ":" + date.getMinutes();
        };
        init();
        if (key) {
            $http.get(url + key).then(function (response) {
                var data = response.data;
                $scope.dayOfWeek = data.dayOfWeek.toString();
                $scope.input = parseFromTimeSpan(data.input);
                $scope.output = parseFromTimeSpan(data.output);
                $scope.interval = parseFromTimeSpan(data.interval);
            });
        }
        $scope.save = function () {
            var entity = {
                dayOfWeek: parseInt($scope.dayOfWeek),
                input: parseToTimeSpan($scope.input),
                output: parseToTimeSpan($scope.output),
                interval: parseToTimeSpan($scope.interval)
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
        };
    }
    return ShiftConfectionController;
}());
main.controller('shiftConfectionController', ['$scope', '$http', "$keyService", ShiftConfectionController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var CollaboratorConfectionController = /** @class */ (function () {
    function CollaboratorConfectionController($scope, $http, keyService) {
        var url = 'api/collaboratorConfection/';
        var key = keyService.key;
        keyService.key = null;
        var init = function () {
            $scope.name = null;
            $scope.email = null;
            $scope.registration = null;
        };
        init();
        if (key) {
            $http.get(url + key).then(function (response) {
                var data = response.data;
                $scope.name = data.name;
                $scope.email = data.email;
                $scope.registration = data.registration;
            });
        }
        $scope.save = function () {
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
        };
    }
    return CollaboratorConfectionController;
}());
main.controller('collaboratorConfectionController', ['$scope', '$http', "$keyService", CollaboratorConfectionController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var ShiftQueryController = /** @class */ (function () {
    function ShiftQueryController($scope, $http, $location, keyService) {
        $scope.source = [];
        $scope.edit = function (id) {
            keyService.key = id;
            $location.path("/shiftConfection");
        };
        $scope.remove = function (id) {
            if (confirm("Deseja excluir esse item?")) {
                $http.delete('api/shiftConfection/' + id).then(function () {
                    alert("excluido!");
                    updateSource();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        };
        var updateSource = function () {
            $http.put('api/shiftQuery/', {}).then(function (response) {
                $scope.source = response.data;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        };
        updateSource();
    }
    return ShiftQueryController;
}());
main.controller('shiftQueryController', ['$scope', '$http', '$location', "$keyService", ShiftQueryController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var CollaboratorQueryController = /** @class */ (function () {
    function CollaboratorQueryController($scope, $http, $location, keyService) {
        $scope.source = [];
        $scope.edit = function (id) {
            keyService.key = id;
            $location.path("/collaboratorConfection");
        };
        $scope.remove = function (id) {
            if (confirm("Deseja excluir esse item?")) {
                $http.delete('api/collaboratorConfection/' + id).then(function () {
                    alert("excluido!");
                    updateSource();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        };
        var updateSource = function () {
            $http.put('api/collaboratorQuery/', {}).then(function (response) {
                $scope.source = response.data;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        };
        updateSource();
    }
    return CollaboratorQueryController;
}());
main.controller('collaboratorQueryController', ['$scope', '$http', '$location', "$keyService", CollaboratorQueryController]);
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
        $scope.markings = [];
        $scope.register = function () {
            $http.put('api/marking/' + registration, null).then(function () {
                updateMarkings();
                alert("registrado!");
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        };
        var updateMarkings = function () {
            $http.get('api/marking/' + registration).then(function (response) {
                $scope.markings = response.data;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        };
        updateMarkings();
    }
    return DefaultController;
}());
main.controller('defaultController', ['$scope', '$http', DefaultController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var KeyService = /** @class */ (function () {
    function KeyService() {
        this.key = null;
    }
    return KeyService;
}());
main.service("$keyService", KeyService);
//# sourceMappingURL=main-ui.js.map