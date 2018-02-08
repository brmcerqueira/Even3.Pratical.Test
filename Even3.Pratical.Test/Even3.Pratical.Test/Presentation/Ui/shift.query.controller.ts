/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class ShiftQueryController {
    constructor($scope: ng.IScope, queryService: QueryService) {
        queryService.setup($scope, "/shiftConfection", 'api/shiftConfection/', 'api/shiftQuery/');
    }
}

main.controller('shiftQueryController', ['$scope', '$queryService', ShiftQueryController]);