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
var ConfectionService = /** @class */ (function () {
    function ConfectionService($http, keyService) {
        this.$http = $http;
        this.keyService = keyService;
    }
    ConfectionService.prototype.setup = function (scope, url, init, load, prepareToSave) {
        var _this = this;
        var key = this.keyService.key;
        this.keyService.key = null;
        init();
        if (key) {
            this.$http.get(url + key).then(function (response) {
                load(response.data);
            });
        }
        scope.save = function () {
            var entity = prepareToSave();
            if (key) {
                _this.$http.post(url + key, entity).then(function () {
                    alert("salvo!");
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
            else {
                _this.$http.put(url, entity).then(function () {
                    alert("salvo!");
                    init();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        };
    };
    return ConfectionService;
}());
main.service('$confectionService', ['$http', "$keyService", ConfectionService]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var MainController = /** @class */ (function () {
    function MainController($scope, $http) {
        $scope.name = "Procurando...";
        var userNotFoundMessage = "Usuário não encontrado!";
        if (registration) {
            $http.get('api/collaborator/' + registration).then(function (response) {
                $scope.name = response.data ? response.data : userNotFoundMessage;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        }
        else {
            $scope.name = userNotFoundMessage;
        }
    }
    return MainController;
}());
main.controller('mainController', ['$scope', '$http', MainController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var QueryService = /** @class */ (function () {
    function QueryService($http, $location, keyService) {
        this.$http = $http;
        this.$location = $location;
        this.keyService = keyService;
    }
    QueryService.prototype.setup = function (scope, editRoute, removeRoute, queryRoute) {
        var _this = this;
        scope.source = [];
        scope.edit = function (id) {
            _this.keyService.key = id;
            _this.$location.path(editRoute);
        };
        scope.remove = function (id) {
            if (confirm("Deseja excluir esse item?")) {
                _this.$http.delete(removeRoute + id).then(function () {
                    alert("excluido!");
                    updateSource();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        };
        var updateSource = function () {
            _this.$http.put(queryRoute, {}).then(function (response) {
                scope.source = response.data;
            }, function (reason) {
                alert(reason.data.exceptionMessage);
            });
        };
        updateSource();
    };
    return QueryService;
}());
main.service('$queryService', ['$http', '$location', "$keyService", QueryService]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var ShiftConfectionController = /** @class */ (function () {
    function ShiftConfectionController($scope, confectionService) {
        var parseFromTimeSpan = function (timeSpan) {
            return new Date('01 01 1970 ' + timeSpan);
        };
        var parseToTimeSpan = function (date) {
            return date.getHours() + ":" + date.getMinutes();
        };
        confectionService.setup($scope, 'api/shiftConfection/', function () {
            $scope.dayOfWeek = "0";
            $scope.input = null;
            $scope.output = null;
            $scope.interval = null;
        }, function (data) {
            $scope.dayOfWeek = data.dayOfWeek.toString();
            $scope.input = parseFromTimeSpan(data.input);
            $scope.output = parseFromTimeSpan(data.output);
            $scope.interval = parseFromTimeSpan(data.interval);
        }, function () {
            return {
                dayOfWeek: parseInt($scope.dayOfWeek),
                input: parseToTimeSpan($scope.input),
                output: parseToTimeSpan($scope.output),
                interval: parseToTimeSpan($scope.interval)
            };
        });
    }
    return ShiftConfectionController;
}());
main.controller('shiftConfectionController', ['$scope', '$confectionService', ShiftConfectionController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var CollaboratorConfectionController = /** @class */ (function () {
    function CollaboratorConfectionController($scope, confectionService) {
        confectionService.setup($scope, 'api/collaboratorConfection/', function () {
            $scope.name = null;
            $scope.email = null;
            $scope.registration = null;
        }, function (data) {
            $scope.name = data.name;
            $scope.email = data.email;
            $scope.registration = data.registration;
        }, function () {
            return {
                name: $scope.name,
                email: $scope.email,
                registration: $scope.registration
            };
        });
    }
    return CollaboratorConfectionController;
}());
main.controller('collaboratorConfectionController', ['$scope', '$confectionService', CollaboratorConfectionController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var ShiftQueryController = /** @class */ (function () {
    function ShiftQueryController($scope, queryService) {
        queryService.setup($scope, "/shiftConfection", 'api/shiftConfection/', 'api/shiftQuery/');
    }
    return ShiftQueryController;
}());
main.controller('shiftQueryController', ['$scope', '$queryService', ShiftQueryController]);
/// <reference path="references.ts"/>
/// <reference path="main.ts"/>
var CollaboratorQueryController = /** @class */ (function () {
    function CollaboratorQueryController($scope, queryService) {
        queryService.setup($scope, "/collaboratorConfection", 'api/collaboratorConfection/', 'api/collaboratorQuery/');
    }
    return CollaboratorQueryController;
}());
main.controller('collaboratorQueryController', ['$scope', '$queryService', CollaboratorQueryController]);
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
        if (registration) {
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