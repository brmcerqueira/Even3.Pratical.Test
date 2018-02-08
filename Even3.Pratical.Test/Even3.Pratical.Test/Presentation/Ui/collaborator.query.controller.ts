/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class CollaboratorQueryController {
    constructor($scope: ng.IScope, queryService: QueryService) {
        queryService.setup($scope, "/collaboratorConfection", 'api/collaboratorConfection/', 'api/collaboratorQuery/');
    }
}

main.controller('collaboratorQueryController', ['$scope', '$queryService', CollaboratorQueryController]);